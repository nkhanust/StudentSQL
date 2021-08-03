using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using studentdatasql.Respositories;
using studentdatasql.Models;
using System.Collections.Generic;

namespace StudentSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonsController : Controller
    {

        private IConfiguration Configuration;
        private static PersonRepository persons;


        public PersonsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
            persons = new PersonRepository(_configuration);

        }

        [HttpGet]
        public List<string> GetPersons()
        {
            return persons.GetPersons();
        }

        [HttpPost]
        public string PostPerson(Person person)
        {
            return persons.PostPerson(person);
        }

        [HttpPut]
        public string PutPerson(Person person)
        {
            return persons.PutPerson(person);
        }

        [HttpDelete ("{Id}")] 
        public string DeletePerson(int Id)
        {
            return persons.DeletePerson (Id);
        }

    }
}
    



        
