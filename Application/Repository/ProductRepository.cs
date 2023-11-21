using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class ProductRepository : GenericRepositoryString<Product>, IProduct
    {
        public JardineriaContext _context { get; }
        public ProductRepository(JardineriaContext context) : base(context)
    {
            _context = context;
    }

        public Task<IEnumerable<object>> GetStock_Products()
        {
            var stock = _context.Products
                .Where(x => x.StockQuantity > 100 && x.ProductLine == "Ornamentales")
                .OrderByDescending(x => x.SellingPrice)  // Agrega esta línea para ordenar por SellingPrice
                .Select(x => new { x.ProductCode, x.Name, x.StockQuantity, x.ProductLine, x.SellingPrice })
                .ToList();

            return Task.FromResult((IEnumerable<object>)stock.Cast<object>());
        }
    }
}