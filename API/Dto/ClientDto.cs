using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ClientDto
    {
        public string ClientName { get; set; } = null!;
        public decimal CreditLimit { get; set; }
        public int IdEmployeeFk { get; set; }
        public int IdContactFk { get; set; }
        public ContactDto IdContactFkNavigation { get; set; }
        public EmployeeDto IdEmployeeFkNavigation { get; set; }
        public List<LocationClientDto> LocationClients { get; set; } = new List<LocationClientDto>();
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
        public List<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }
}