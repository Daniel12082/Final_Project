using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class LocationClientRepository : GenericRepository<LocationClient>, ILocationClient
    {
        public LocationClientRepository(JardineriaContext context) : base(context)
    {
    }
    }
}