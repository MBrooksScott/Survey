using Dapper;
using Microsoft.Extensions.Configuration;
using Survey.Data.Interfaces;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AllMeds.Common.DAL;
using System.Data;

namespace Survey.Data
{
    public class SurveyRepository : ISurveyRepository
    {
        private string _connectionString;
        public SurveyRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        public async Task<SurveyModel> GetSurvey(string CustomerNumber, Guid SurveyId)
        {
            SurveyModel survey;
            IEnumerable<CategoryModel> categories;
            IEnumerable<QuestionModel> questions;
            IEnumerable<AnswerModel> answers;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DynamicParameters p  = new DynamicParameters();
                p.Add("@CustomerNumber", CustomerNumber, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                p.Add("@SurveyId", SurveyId, System.Data.DbType.Guid, System.Data.ParameterDirection.Input);

                using (var multi = await connection.QueryMultipleAsync("dbo.Survey_GET", p, commandType: System.Data.CommandType.StoredProcedure))
                {
                    survey = multi.Read<SurveyModel>().First();
                    categories = multi.Read<CategoryModel>().ToList();
                    questions = multi.Read<QuestionModel>().ToList();
                    answers = multi.Read<AnswerModel>().ToList();
                }
            }

            survey.Categories = categories;
            foreach(QuestionModel question in questions)
            {
                question.Answers = answers.Where(a => a.SurveyId == SurveyId && a.QuestionId == question.QuestionId).ToList();
            }
            foreach(CategoryModel category in survey.Categories)
            {
                category.Questions = questions.Where(q => q.SurveyId == SurveyId && q.CategoryId == category.CategoryId).ToList();
            }

            return survey;
        }

        public async Task<IEnumerable<SurveyModel>> GetSurveyList(string CustomerNumber)
        {
            IEnumerable<SurveyModel> surveys;
            using (var connection = new SqlConnection(_connectionString))
            {
                surveys = await connection.QueryAsync<SurveyModel>("dbo.SurveyList_GET", new { CustomerNumber }, commandType: System.Data.CommandType.StoredProcedure);
            }
            return surveys;
        }

        public async Task SaveSurvey(FormSaveRequest saveRequest)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("dbo.SaveHXForm", connection);
                cmd.Parameters.Add(new SqlParameter("PracticeId", System.Data.SqlDbType.Int) { Value=saveRequest.PracticeId });
                cmd.Parameters.Add(new SqlParameter("PatientId", System.Data.SqlDbType.Int) { Value = saveRequest.PatientId });
                cmd.Parameters.Add(new SqlParameter("FormId", System.Data.SqlDbType.UniqueIdentifier) { Value = saveRequest.FormId });
                cmd.Parameters.Add(new SqlParameter("Details", System.Data.SqlDbType.Structured));

                var dt = new DataTable();
                dt.Columns.Add("AnswerId", typeof(int));
                dt.Columns.Add("AnswerDate", typeof(DateTime));
                dt.Columns["AnswerDate"].AllowDBNull = true;

                foreach(AnswerSaveRequest answer in saveRequest.Answers)
                {
                    var dr = dt.NewRow();
                    dr["AnswerId"] = answer.AnswerId;
                    dr["AnswerDate"] = answer.AnswerDate;
                    dt.Rows.Add(dr);
                }
                cmd.Parameters["Details"].Value = dt;

                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
