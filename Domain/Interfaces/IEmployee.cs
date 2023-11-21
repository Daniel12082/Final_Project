using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployee : IGeneric<Employee>
    {
        Task<IEnumerable<object>> GetEmployeesByBossCode();
        Task<IEnumerable<object>> GetEmployeesByBossCode(int bossCode);
        Task<IEnumerable<object>> GetEmployeesByDepartment(int departmentId);
        Task<object> GetEmployeesQuantity();
    }
}