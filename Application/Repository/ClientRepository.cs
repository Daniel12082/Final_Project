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
    public class ClientRepository : GenericRepository<Client>, IClient
    {
        public JardineriaContext _context { get; set; }
        public ClientRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }   
        public async Task<IEnumerable<object>> GetCitiesOfSpain()
        {
            var citiesOffices = await (
                from client in _context.Clients
                join locationCustomer in _context.LocationCustomers on client.IdContactFk equals locationCustomer.IdClientFk
                join city in _context.Cities on locationCustomer.IdCityFk equals city.Id
                join state in _context.States on city.IdStateFk equals state.Id
                join country in _context.Countries on state.IdCountryFk equals country.Id
                where country.Name == "España"
                select new { client.ClientName, country.Name}
            ).ToListAsync();

        return citiesOffices;
        }
        public async Task<IEnumerable<object>> GetClientsWithPaymentsIn2008()
        {
            var results = await (
                from c in _context.Clients
                join p in _context.Payments on c.Id equals p.ClientCode
                where p.PaymentDate.Year == 2008
                select new { c.Id,  c.ClientName }
            ).Distinct().ToListAsync();

            return results;
        }
        public async Task<IEnumerable<object>> GetClientsMadridRepresent()
        {
            var clientesMadrid = await (from cliente in _context.Clients
                                        join location in _context.LocationCustomers on cliente.Id equals location.IdClientFk
                                        join city in _context.Cities on location.IdCityFk equals city.Id
                                        where city.Name == "Madrid" &&
                                                (cliente.IdEmployeeFk == 11 || cliente.IdEmployeeFk == 30)
                                        select new
                                        {
                                            Cliente = cliente,
                                            Ciudad = city
                                        }).ToListAsync();

            return clientesMadrid;
        }
        public async Task<IEnumerable<object>> GetClientAndRepresent()
        {
                var query = (from c in _context.Clients
                    join p in _context.Payments on c.Id equals p.ClientCode
                    join e in _context.Employees on c.IdEmployeeFk equals e.Id
                    where _context.Payments.Any(payment => payment.ClientCode == c.Id) &&
                        e.Position == "Representante Ventas"
                    select new
                    {
                        NombreCliente = c.ClientName,
                        NombreRepresentante = e.FirstName
                    }).Distinct();

        return await query.ToListAsync();
        }
        public async Task<IEnumerable<object>> GetClientWithOutPayAndRepresent()
        {
            var query = (from c in _context.Clients
                        join e in _context.Employees on c.IdEmployeeFk equals e.Id
                        join p in _context.Payments on c.Id equals p.ClientCode into payments
                        from payment in payments.DefaultIfEmpty()
                        where payment == null && e.Position == "Representante Ventas"
                        select new
                        {
                            NombreCliente = c.ClientName,
                            NombreRepresentante = e.FirstName
                        }).Distinct();

            return await query.ToListAsync();
        }
    }
}