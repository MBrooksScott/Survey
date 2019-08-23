using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survey.Data.Interfaces;
using Survey.Models;

namespace Survey.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private ISurveyRepository _repo;
        public SurveyController(ISurveyRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet("{CustomerNumber}/{SurveyId}")]
        [Authorize]
        public async Task<SurveyModel> Get(string CustomerNumber, Guid SurveyId)
        {
            return await _repo.GetSurvey(CustomerNumber, SurveyId);
        }

        [HttpGet("{CustomerNumber}")]
        [Authorize]
        public async Task<IEnumerable<SurveyModel>> Get (string CustomerNumber) {
            return await _repo.GetSurveyList(CustomerNumber);
        }

        [HttpPost]
        [Authorize]
        public async Task Post(FormSaveRequest model)
        {
            await _repo.SaveSurvey(model);
        }
    }
}
