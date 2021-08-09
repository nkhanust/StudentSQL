using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using studentdatasql.Respositories;
using studentdatasql.Models;
using System.Collections.Generic;
using Serilog;

namespace StudentSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonsController : Controller
    {
        private IConfiguration Configuration;
        private static PersonRepository persons;
        ILogger _logger;


        public PersonsController(IConfiguration _configuration, ILogger logger)
        {
            Configuration = _configuration;
            persons = new PersonRepository(_configuration);
            _logger = logger;
        }

        [HttpGet]
        public List<string> GetPersons()
        {
            List<string> personList = persons.GetPersons();
            foreach (string y in personList)
            {
                _logger.Information(y);
            }
            return personList;
        }

        [HttpPost]
        public string PostPerson(Person person)
        {

            _logger.Information(" Person inserted: " + person.Id + " " + person.FirstName + " " + person.LastName + " " + person.SupervisorId + " " + person.BranchId);
            return persons.PostPerson(person);
        }

        [HttpPut]
        public string PutPerson(Person person)
        {
            _logger.Information(" Person updated: " + person.Id + " " + person.FirstName + " " + person.LastName + " " + person.SupervisorId + " " + person.BranchId);
            return persons.PutPerson(person);
        }

        [HttpDelete("{Id}")]
        public string DeletePerson(int Id)
        {
            _logger.Information("Person with ID number" + Id + " has been deleted from the records");
            return persons.DeletePerson(Id);
        }

    }
}
    



        
