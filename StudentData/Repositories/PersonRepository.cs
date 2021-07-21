using sql_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentData.Interfaces;

namespace StudentData.Repositories
{
    class PersonRepository : IPersonRespository
    {

        public List<Person> persons = new List<Person>()
        {
            new Person {Id = 1, FirstName = "Nabeel", LastName = "Khan", SupervisorId = 1, BranchId = 100}
        };


        public List<Person> GetAllPersons()
        {
            return persons;
        }

        public Person GetPerson(int id)
        {
            return persons.FirstOrDefault(x => x.Id == id);
        }
    }
}
