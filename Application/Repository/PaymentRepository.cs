using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class PaymentRepository : GenericRepositoryString<Payment>, IPayment
    {
        public PaymentRepository(JardineriaContext context) : base(context)
    {
    }
    }
}