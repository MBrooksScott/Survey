using Survey.Data.Interfaces;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Data
{
    public class SurveyTestRepo : ISurveyRepository
    {
        public Task<SurveyModel> GetSurvey(string CustomerNumber, Guid SurveyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SurveyModel>> GetSurveyList(string CustomerNumber)
        {
            throw new NotImplementedException();
        }

        public Task SaveSurvey(FormSaveRequest saveRequest)
        {
            throw new NotImplementedException();
        }
    }
}
