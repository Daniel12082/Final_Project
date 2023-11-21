using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string ContactName { get; set; } = null!;
        public string ContactLastName { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public List<ClientDto> Clients { get; set; } = new List<ClientDto>();
    }
}