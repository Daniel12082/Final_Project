using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class OrderDto
    {
        public int Id {get; set;}
        public DateOnly OrderDate { get; set; }
        public DateOnly ExpectedDate { get; set; }
        public DateOnly? DeliveryDate { get; set; }
        public string Status { get; set; } = null!;
        public string Comments { get; set; } = null!;
        public int ClientCode { get; set; }
        public ClientDto ClientCodeNavigation { get; set; } = null!;
        public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }
}