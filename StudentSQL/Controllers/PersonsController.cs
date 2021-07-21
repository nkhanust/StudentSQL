using Microsoft.AspNetCore.Mvc;
using sql_web_api.Models;
using System.Collections.Generic;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
namespace StudentSQL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PersonsController : ControllerBase
    {
        //public List<Person> persons = new List<Person>()
        //{
        //    new Person {Id = 1, FirstName = "Nabeel", LastName = "Khan", SupervisorId = 1, BranchId = 100}
        //};

        private IPersonRepository persons = new PersonRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            return Persons;
        }

        [HttpGet("{id}")]

        public ActionResult<Person> GetPerson(int id)
        {
            var person = person.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }
    }



}
