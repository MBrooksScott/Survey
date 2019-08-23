using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Data.Interfaces;
using Survey.Models;

namespace Survey.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepo _repo;
        public PersonController(IPersonRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return _repo.GetPeople();
        }

        [HttpGet("{Id}")]
        public Person GetPerson(int Id)
        {
            return _repo.GetPerson(Id);
        }
    }
}