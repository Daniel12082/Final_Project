using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class EmployeeDto
    {
        public int Id{get; set;}
        public string FirstName { get; set; }

        public string LastName1 { get; set; } = null!;

        public string LastName2 { get; set; }

        public string Extension { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string OfficeCode { get; set; } = null!;
    }
}