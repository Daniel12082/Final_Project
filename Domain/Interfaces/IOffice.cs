using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOffice : IGenericString<Office>
    {
        Task<IEnumerable<object>> GetCities_Offices();
        Task<IEnumerable<object>> GetPais_Cities_Offices();
        Task<IEnumerable<object>> GetClient_Offices();
        Task<IEnumerable<object>> GetNotFrutales_Offices();
        Task<IEnumerable<object>> GetNotClient_Offices();
        Task<IEnumerable<object>> GetCities_Employees_Offices();
    }
}