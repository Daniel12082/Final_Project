using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class EmployeeDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName1 { get; set; } = null!;
        public string LastName2 { get; set; }
        public string Extension { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string OfficeCode { get; set; } = null!;
        public int IdBossFk { get; set; }
        public string Position { get; set; }
        public List<ClientDto> Clients { get; set; } = new List<ClientDto>();
        public BossDto IdBossFkNavigation { get; set; } = null!;
        public OfficeDto OfficeCodeNavigation { get; set; } = null!;
    }
}