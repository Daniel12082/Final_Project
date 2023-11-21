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
    }
}