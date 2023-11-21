using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ProviderDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public int DentificationArd { get; set; }
        public int Cellphone { get; set; }
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}