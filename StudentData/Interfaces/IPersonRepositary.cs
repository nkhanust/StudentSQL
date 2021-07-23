using StudentData.Models;
using System.Collections.Generic;

namespace StudentData.Interfaces
{
    interface IPersonRepositary
    {
        List<Person> GetALlPersons();

        Person GetPerson(int id);
    }
}
