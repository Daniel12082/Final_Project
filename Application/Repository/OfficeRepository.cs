using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
    public async Task<IEnumerable<object>> GetClient_Offices()
    {
        return await (from LocationClient in _context.LocationCustomers
                join city in _context.Cities on LocationClient.IdCityFk equals city.Id
                where city.Name == "Bucaramanga"
                join client in _context.Clients on LocationClient.IdClientFk equals client.Id
                join employee in _context.Employees on client.IdEmployeeFk equals employee.Id
                join office in _context.Offices on employee.OfficeCode equals office.Id
                join locationOffice in _context.LocationOffices on office.LocationOfficeFk equals locationOffice.Id                
                select new { OfficeId = employee.OfficeCode, OfficeAddress = GetFormattedAddress(locationOffice), NameClient = client.ClientName, CityName = city.Name })
                .ToListAsync();
                //Lista la dirección de las oficinas que tengan clientes en Fuenlabrada
    }
    private static string GetFormattedAddress(LocationOffice locationOffice)
    {
        var addressBuilder = new StringBuilder();

        var addressPart1 = string.IsNullOrEmpty(locationOffice.TipoDeVia) ? "" : locationOffice.TipoDeVia;
        var addressPart2 = string.IsNullOrEmpty(locationOffice.NumeroPri.ToString()) ? "" : locationOffice.NumeroPri.ToString();
        var addressPart3 = string.IsNullOrEmpty(locationOffice.Letra) ? "" : locationOffice.Letra;
        var addressPart4 = string.IsNullOrEmpty(locationOffice.Bis) ? "" : locationOffice.Bis;
        var addressPart5 = string.IsNullOrEmpty(locationOffice.Letrasec) ? "" : locationOffice.Letrasec;
        var addressPart6 = string.IsNullOrEmpty(locationOffice.Cardinal) ? "" : locationOffice.Cardinal;
        var addressPart7 = string.IsNullOrEmpty(locationOffice.NumeroSec.ToString()) ? "" : locationOffice.NumeroSec.ToString();
        var addressPart8 = string.IsNullOrEmpty(locationOffice.Letrater) ? "" : locationOffice.Letrater;
        var addressPart9 = string.IsNullOrEmpty(locationOffice.NumeroTer.ToString()) ? "" : locationOffice.NumeroTer.ToString();
        var addressPart10 = string.IsNullOrEmpty(locationOffice.CardinalSec) ? "" : locationOffice.CardinalSec;
        var addressPart11 = string.IsNullOrEmpty(locationOffice.Complemento) ? "" : locationOffice.Complemento;
        var combinedAddress = $"{addressPart1} {addressPart2} {addressPart3} {addressPart4} {addressPart5} {addressPart6} {addressPart7} {addressPart8} {addressPart9} {addressPart10} {addressPart11}".Trim();

        return combinedAddress;
    }
    public async Task<IEnumerable<object>> GetNotFrutales_Offices()
    {
        return await (from office in _context.Offices
                join employee in _context.Employees on office.Id equals employee.OfficeCode
                join client in _context.Clients on employee.Id equals client.IdEmployeeFk
                join order in _context.Orders on client.Id equals order.ClientCode
                join detailOrder in _context.OrderDetails on order.Id equals detailOrder.Id
                join product in _context.Products on detailOrder.ProductCode equals product.Id
                where product.ProductLine != "Frutales"
                select new { OfficeId = office.Id})
                .ToListAsync();
                //Lista las oficinas que no tengan clientes que hayan comprado productos de la categoría Frutales
    }
    }
}