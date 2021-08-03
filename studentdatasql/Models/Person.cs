using System.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentdatasql.Models
{
    public class Person
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SupervisorId { get; set; }

        public int BranchId { get; set; }
    }
}

