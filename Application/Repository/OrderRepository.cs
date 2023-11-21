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
        
    }
}