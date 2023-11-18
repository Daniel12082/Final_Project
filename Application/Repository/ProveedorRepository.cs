using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
    {
        public ProveedorRepository(JardineriaContext context) : base(context)
    {
    }
    }
}