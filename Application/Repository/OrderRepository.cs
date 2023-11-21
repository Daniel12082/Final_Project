using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrder
    {
        public JardineriaContext _context { get; }
        public OrderRepository(JardineriaContext context) : base(context)
    {
            _context = context;
    }

        public Task<IEnumerable<object>> GetStatus_Order()
        //public Task<IEnumerable<object>> GetDistinctStatus_Order()
{
    var distinctStatus = _context.Orders
        .Select(x => x.Status)
        .Distinct()
        .Select(status => new { Status = status })
        .ToList();

    return Task.FromResult((IEnumerable<object>)distinctStatus.Cast<object>());
}
        
        public Task<IEnumerable<object>> GetDelayed_Order()
        {
            var delayed = _context.Orders
                .Where(x => x.Status == "Entregado")
                .Where(x => x.ExpectedDate < x.DeliveryDate)
                .Select(x => new { x.Id, x.ClientCode, x.ExpectedDate, x.DeliveryDate, x.Status })
                .ToList();

            return Task.FromResult((IEnumerable<object>)delayed.Cast<object>());
        }

        public Task<IEnumerable<object>> GetAdvanced_Order()
        {
            var delayed = _context.Orders
                .Where(x => x.Status == "Entregado" && (x.ExpectedDate > x.DeliveryDate))
                .Select(x => new { x.Id, x.ClientCode, x.ExpectedDate, x.DeliveryDate, x.Status })
                .ToList();

            return Task.FromResult((IEnumerable<object>)delayed.Cast<object>());
        }
    }
}