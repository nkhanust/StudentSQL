using System.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sql_web_api.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SupervisorId { get; set; }

        public int BranchId { get; set; }
    }
}

