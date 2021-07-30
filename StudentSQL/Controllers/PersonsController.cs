using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using studentdatasql.Respositories;
using studentdatasql.Models;


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
        public void GetPerson()
        {
            persons.GetPerson();
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

        [HttpDelete]
        public string DeletePerson(Person person)
        {
            return persons.DeletePerson(person);
        }

    }
}
    



        
