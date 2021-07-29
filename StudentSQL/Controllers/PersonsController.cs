using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace StudentSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonsController : Controller
    {

        private IConfiguration Configuration;
        private static PersonsRepository persons;


        public PersonsController(IConfiguration_configuration)
        {
            Configuration = _configuration;
            //persons - new PersonsRepository(_configuration);

        }

        [HttpGet]
        public void GetPerson()
        {
            persons.GetPerson();
        }

        [HttpPost]
        public void PostPerson(Person person)
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
    



        
