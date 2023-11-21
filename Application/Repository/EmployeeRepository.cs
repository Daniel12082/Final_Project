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
public async Task<IEnumerable<object>> GetEmployeesByBossCode(int bossCode)    {
    try
    {
        var employees = await (
            from employee in _context.Employees
            where employee.IdBossFk == bossCode
            select new
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName1,
                LastName2 = employee.LastName2,
                Email = employee.Email
            }
        ).ToListAsync();

        return employees;
    }
    catch (Exception ex)
    {
        // Manejar la excepción según tus necesidades (puedes registrarla o mostrarla en la salida)
        Console.WriteLine($"Error al obtener empleados: {ex.Message}");
        throw; // Puedes elegir relanzar la excepción o manejarla de manera diferente
    }
    }

        public Task<IEnumerable<object>> GetEmployeesByBossCode()
        {
            throw new NotImplementedException();
        }   
//1. ¿Cuántos empleados hay en la compañía?
        public async Task<object> GetEmployeesQuantity()
        {
            return new { EmployeesQuantity = await _context.Employees.CountAsync() };
        }
//9.Devuelve un listado que muestre el nombre de cada empleados, el nombre de su jefe y el nombre del jefe de sus jefe.
    public async Task<IEnumerable<object>> GetNameAndBossChief()
    {
        return await _context.Employees
                .Select(c => new
                {
                    c.FirstName,
                    Boss = c.IdBossFkNavigation.Name,
                    Chief = c.IdBossFk

                })
                .ToListAsync();
}
        public Task<IEnumerable<object>> GetEmployeesByDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

    }

}