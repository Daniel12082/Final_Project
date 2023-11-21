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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployee
    {
        public JardineriaContext _context { get; }
        public EmployeeRepository(JardineriaContext context) : base(context)
    {
            _context = context;
    }
    public async Task<IEnumerable<object>> GetEmployeesWithBossCode7()
    {
        var query = from employee in _context.Employees
                    join boss in _context.Bosses on employee.IdBossFk equals boss.Id
                    where boss.Id == 7
                    select new
                    {
                        employee.FirstName,
                        employee.LastName1,
                        employee.LastName2,
                        employee.Email
                    };

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<object>> GetBossInformation()
    {
        var query = from boss in _context.Bosses
                    join employee in _context.Employees on boss.Id equals employee.IdBossFk
                    select new
                    {
                        PositionName = employee.Position, // Asumiendo que el nombre del puesto está en el atributo 'Position' de Employee
                        boss.Name,
                        employee.LastName1,
                        employee.LastName2,
                        employee.Email
                    };

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<object>> GetNonSalesRepresentatives()
    {
        var query = from employee in _context.Employees
                    where employee.Position != "Representante de Ventas"
                    select new
                    {
                        employee.FirstName,
                        employee.LastName1,
                        employee.LastName2,
                        employee.Position,
                    };

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<object>> GetEmployeeBossInformation()
    {
        var query = from employee in _context.Employees
                    join boss in _context.Bosses on employee.IdBossFk equals boss.Id
                    select new
                    {
                        BossName = boss.Name,
                        employee.FirstName,
                        employee.LastName1,
                        employee.LastName2,
                    };

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<object>> GetEmployeeHierarchy()
    {
        var query = from employee in _context.Employees
                    join boss in _context.Bosses on employee.IdBossFk equals boss.Id into employeeBossJoin
                    from employeeBoss in employeeBossJoin.DefaultIfEmpty()
                    join grandBoss in _context.Bosses on employeeBoss.Id equals grandBoss.Id into employeeGrandBossJoin
                    from employeeGrandBoss in employeeGrandBossJoin.DefaultIfEmpty()
                    join grandGrandBoss in _context.Bosses on employeeGrandBoss.Id equals grandGrandBoss.Id into employeeGrandGrandBossJoin
                    from employeeGrandGrandBoss in employeeGrandGrandBossJoin.DefaultIfEmpty()
                    select new
                    {
                        EmployeeName = $"{employee.FirstName} {employee.LastName1} {employee.LastName2}",
                        BossName = employeeBoss != null ? employeeBoss.Name : null,
                        GrandBossName = employeeGrandBoss != null ? employeeGrandBoss.Name : null,
                        GrandGrandBossName = employeeGrandGrandBoss != null ? employeeGrandGrandBoss.Name : null
                    };

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<object>> GetEmployeesWithoutOffice()
    {
        var query = from employee in _context.Employees
                    where employee.OfficeCode == null
                    select new
                    {
                        employee.FirstName,
                        employee.LastName1,
                        employee.LastName2,
                        employee.Email
                    };

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<object>> GetEmployeesWithoutClient()
    {
        var query = from employee in _context.Employees
                    where !_context.Clients.Any(client => client.IdEmployeeFk == employee.Id)
                    select new
                    {
                        employee.FirstName,
                        employee.LastName1,
                        employee.LastName2,
                        employee.Email
                    };

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<object>> GetEmployeesWithoutClientAndOffice()
    {
        var query = from employee in _context.Employees
                    where !_context.Clients.Any(client => client.IdEmployeeFk == employee.Id)
                    && employee.OfficeCode != null // Asegura que el empleado tenga una oficina asociada
                    join office in _context.Offices on employee.OfficeCode equals office.Id
                    select new
                    {
                        EmployeeName = $"{employee.FirstName} {employee.LastName1} {employee.LastName2}",
                        employee.Email,
                        OfficeName = office.Id, // Ajusta esto según la estructura real de tu base de datos
                        office.Phone
                    };

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<object>> GetEmployeesWithoutClientsAndBoss()
    {
        var query = from employee in _context.Employees
                    where !_context.Clients.Any(client => client.IdEmployeeFk == employee.Id)
                    join boss in _context.Bosses on employee.IdBossFk equals boss.Id into employeeBossJoin
                    from employeeBoss in employeeBossJoin.DefaultIfEmpty()
                    select new
                    {
                        EmployeeName = $"{employee.FirstName} {employee.LastName1} {employee.LastName2}",
                        employee.Email,
                        BossName = employeeBoss != null ? employeeBoss.Name : "No tiene jefe asociado"
                    };
        return await query.ToListAsync();
    }
        public async Task<IEnumerable<object>> GetEmployeesWithoutClients()
        {
        var query = from employee in _context.Employees
                    where !_context.Clients.Any(client => client.IdEmployeeFk == employee.Id)
                    select new
                    {
                        employee.FirstName,
                        employee.LastName1,
                        employee.LastName2,
                        employee.Position
                    };

        return await query.ToListAsync();
        }
        public async Task<IEnumerable<object>> GetEmployeesUnderPatriciaGomezHernandez()
        {
        var query = from employee in _context.Employees
                    join Boss in _context.Bosses on employee.IdBossFk equals Boss.Id
                    where Boss.Name == "Patricia Gómez Hernández"
                    select new
                    {
                        employee.FirstName,
                        employee.LastName1,
                        employee.LastName2,
                        employee.Email
                    };

        return await query.ToListAsync();
        }
        public async Task<IEnumerable<object>> GetEmployeesWithoutNotClients()
{
    var query = from employee in _context.Employees
                where !_context.Clients.Any(client => client.IdEmployeeFk == employee.Id)
                select new
                {
                    employee.FirstName,
                    employee.LastName1,
                    employee.LastName2,
                    employee.Position
                };

    return await query.ToListAsync();
}


    }
    }

