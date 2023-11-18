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
        public ProductRepository(JardineriaContext context) : base(context)
    {
    }
    }
}