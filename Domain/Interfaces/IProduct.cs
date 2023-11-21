using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProduct : IGenericString<Product>
    {
        Task<IEnumerable<object>> GetStock_Products();
    }
}