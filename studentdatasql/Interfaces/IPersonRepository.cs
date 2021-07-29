using studentdatasql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentdatasql.Interfaces
{
    interface IPersonRepositor
    {
        void GetPerson();

        string PostPerson(Person person );

        string PutPerson(Person person);

        string DeletePerson(Person person);
    }

    
}
