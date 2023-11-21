using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public string ProductCode { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public short LineNumber { get; set; }
        public OrderDto OrderCodeNavigation { get; set; } = null!;
        public ProductDto ProductCodeNavigation { get; set; } = null!;
    }
}