using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class StateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCountryFk { get; set; }
        public List<CityDto> Cities { get; set; } = new List<CityDto>();
        public CountryDto IdCountryFkNavigation { get; set; }
    }
}