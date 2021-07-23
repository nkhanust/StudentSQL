using Microsoft.AspNetCore.Mvc;
using sql_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSQL.Controllers

{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonsController : ControllerBase
    {
        //Adding new person to database
        public List<Person> persons = new()
        {
            new Person {Id = 1, FirstName = "Nabeel", LastName = "Khan", SupervisorId = 1, BranchId = 100}
        };

        //Get methods below
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            return persons;
        }


        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person = persons.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }
    }
}