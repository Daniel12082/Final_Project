using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StateDto> States { get; set; } = new List<StateDto>();
    }
}