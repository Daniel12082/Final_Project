using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PaymentRepository : GenericRepositoryString<Payment>, IPayment
    {
        public JardineriaContext _context { get; set; }
        public PaymentRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<object>> GetPayments()
        {
            var payments = await _context.Payments
                .Where(p => p.PaymentMethod == "Paypal" && p.PaymentDate.Year == 2008)
                .OrderByDescending(p => p.Total)
                .ToListAsync();

            return payments.Select(p => new
            {
                p.Id,
                p.PaymentMethod,
                p.TransactionId,
                PaymentDate = p.PaymentDate.ToString(),
                p.Total,
                p.ClientCode
            });
        }
        public async Task<IEnumerable<object>> GetUniquePaymentMethods()
{
    var uniquePaymentMethods = await _context.Payments
        .Select(p => p.PaymentMethod)
        .Distinct()
        .ToListAsync();

    return uniquePaymentMethods.Select(method => new { PaymentMethod = method });
}

}
}

