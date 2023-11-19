using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ProductDto
    {
        public string Id { get; set; } 
        public string ProductCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string ProductLine { get; set; } = null!;
        public string Dimensions { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public short StockQuantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal SupplierPrice { get; set; }
        public int IdProviderFk { get; set; }
        public ProveedorDto IdProviderFkNavigation { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
        public ProductLineDto ProductLineNavigation { get; set; } = null!;
    }
}