using Survey.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Data.Interfaces
{
    public interface ISurveyRepository
    {
        Task<SurveyModel> GetSurvey(string CustomerNumber, Guid SurveyId);
        Task<IEnumerable<SurveyModel>> GetSurveyList(string CustomerNumber);
        Task SaveSurvey(FormSaveRequest saveRequest);
    }
}
