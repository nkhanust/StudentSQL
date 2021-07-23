using System.Collections.Generic;
using System.Linq;
using StudentData.Interfaces;
using StudentData.Models;

namespace StudentData.Repositories
{
    class PersonRepository : IPersonRepositary
    {

        public List<Person> persons = new List<Person>()
        {
            new Person {Id = 1, FirstName = "Nabeel", LastName = "Khan", SupervisorId = 1, BranchId = 100}
        };


        public List<Person> GetAllPersons()
        {
            return persons;
        }

        public List<Person> GetALlPersons()
        {
            throw new System.NotImplementedException();
        }

        public Person GetPerson(int id)
        {
            return persons.FirstOrDefault(x => x.Id == id);
        }
    }
}
