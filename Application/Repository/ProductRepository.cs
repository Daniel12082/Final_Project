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

        public Task<IEnumerable<object>> GetProductLine_Client_Products()
            {
                var productLinesByClient = _context.Products
                    .Join(_context.OrderDetails, p => p.ProductCode, od => od.ProductCode, (p, od) => new { p.ProductLine, od.Id})
                    .Join(_context.Orders, od => od.Id, o => o.Id, (od, o) => new { od.ProductLine, o.ClientCode })
                    .Join(_context.Clients, o => o.ClientCode, c => c.Id, (o, c) => new { c.Id, c.ClientName, o.ProductLine })
                    .GroupBy(x => new { x.Id, x.ClientName })
                    .Select(group => new
                    {
                        ClientCode = group.Key.Id,
                        ClientName = group.Key.ClientName,
                        ProductLines = group.Select(x => x.ProductLine).Distinct().ToList()
                    })
                    .ToList();

                return Task.FromResult((IEnumerable<object>)productLinesByClient.Cast<object>());
            }
    }
}