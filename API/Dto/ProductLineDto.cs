using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ProductLineDto
    {
        public string Id { get; set; } 
        public string DescriptionText { get; set; }
        public string DescriptionHtml { get; set; }
        public string Image { get; set; }
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}