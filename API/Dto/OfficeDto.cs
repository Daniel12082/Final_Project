using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class OfficeDto
    {
        public string Id {get; set;}
        public string Phone { get; set; }

        public int LocationOfficeFk { get; set; }
    }
}