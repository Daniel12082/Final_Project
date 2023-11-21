using System;
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
    public class OfficeRepository : GenericRepositoryString<Office>, IOffice
    {
        public JardineriaContext _context { get; set; }
        public OfficeRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<object>> GetCities_Offices()
        {
            return await (from office in _context.Offices
                join LocationOffice in _context.LocationOffices on office.LocationOfficeFk equals LocationOffice.Id
                join city in _context.Cities on LocationOffice.IdCityFk equals city.Id
                select new { office.Id, city.Name })
                .ToListAsync();
                
        }
    public async Task<IEnumerable<object>> GetPais_Cities_Offices()
    {
        return await (from office in _context.Offices
                join LocationOffice in _context.LocationOffices on office.LocationOfficeFk equals LocationOffice.Id
                join city in _context.Cities on LocationOffice.IdCityFk equals city.Id
                join state in _context.States on city.IdStateFk equals state.Id
                join country in _context.Countries on state.IdCountryFk equals country.Id
                where country.Name == "España"
                select new { OfficeId = office.Id, office.Phone, CityName = city.Name, CountryName = country.Name })
                .ToListAsync();
    }
    }
}