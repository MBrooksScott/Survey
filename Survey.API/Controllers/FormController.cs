using Microsoft.AspNetCore.Mvc;
using Survey.Data.Interfaces;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FormController : ControllerBase
    {
        private IFormRepository _repo;
        public FormController(IFormRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<OutlineItem>> GetOutlineItems()
        {
            return await _repo.GetOutlineItems();
        }
    }
}
