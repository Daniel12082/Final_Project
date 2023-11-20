using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class PaymentDto
    {
        public string Id { get; set; } 
        public string PaymentMethod { get; set; } = null!;
        public string TransactionId { get; set; } = null!;
        public DateOnly PaymentDate { get; set; }
        public decimal Total { get; set; }
        public int ClientCode { get; set; }
        public ClientDto ClientCodeNavigation { get; set; } = null!;
    }
}