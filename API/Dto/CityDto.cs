using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class CityDto
    {
        public string Name { get; set; }
        public int IdStateFk { get; set; }
        public StateDto IdStateFkNavigation { get; set; }
        public List<LocationClientDto> LocationClients { get; set; } = new List<LocationClientDto>();
        public List<LocationOfficeDto> LocationOffices { get; set; } = new List<LocationOfficeDto>();
    }
}