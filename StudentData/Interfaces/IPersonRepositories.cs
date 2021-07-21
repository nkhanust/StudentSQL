using sql_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Interfaces
{
    interface IPersonRepositories
    {
        List<Person> GetALlPersons();

        Person GetPerson(int id);
    }
}
