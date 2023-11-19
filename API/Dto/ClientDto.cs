using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = null!;

        public decimal CreditLimit { get; set; }

        public int IdEmployeeFk { get; set; }

        public int IdContactFk { get; set; }
    }
}