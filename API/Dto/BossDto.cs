using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class BossDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? DentificationArd { get; set; }
        public int? Cellphone { get; set; }
        public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}