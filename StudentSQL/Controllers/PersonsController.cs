using Microsoft.AspNetCore.Mvc;
using sql_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using sql.client;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


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
            try
            {
                string ConnectingString = this.Configuration.GetConnection("MyConnection");
                using (SqlConnection con = new sqlConnection(ConnectingString))
                {
                    con.Open();
                    SqlCommand Command = new SqlCommand("SelectAllitem", con);
                    Command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           Console.WriteLine(string.Format)
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            

            
        }
    }
}