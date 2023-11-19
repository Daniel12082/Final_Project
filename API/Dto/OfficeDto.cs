using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class OfficeDto
    {
        public string Id { get; set; } 
        public string Phone { get; set; } = null!;
        public int LocationOfficeFk { get; set; }
        public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        public LocationOfficeDto LocationOfficeFkNavigation { get; set; } = null!;
    }
}