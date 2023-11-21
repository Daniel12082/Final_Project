using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClient : IGeneric<Client>
    {
        Task<IEnumerable<object>> GetCitiesOfSpain();
        Task<IEnumerable<object>> GetClientsWithPaymentsIn2008();
        Task<IEnumerable<object>> GetClientsMadridRepresent();
        Task<IEnumerable<object>> GetClientAndRepresent();
        Task<IEnumerable<object>> GetClientWithOutPayAndRepresent();
    }
}