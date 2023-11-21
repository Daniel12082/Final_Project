using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrder : IGeneric<Order>
    {
        Task<IEnumerable<object>> GetStatus_Order();
        Task<IEnumerable<object>> GetDelayed_Order();
        Task<IEnumerable<object>> GetAdvanced_Order();
        Task<IEnumerable<object>> GetReturned_Order();
        Task<IEnumerable<object>> GetDelivered_Order();
        Task<IEnumerable<object>> GetStatus_Cantity_Order();
    }
}