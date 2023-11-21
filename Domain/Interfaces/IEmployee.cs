using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployee : IGeneric<Employee>
    {
        Task<IEnumerable<object>> GetEmployeesWithBossCode7();
        Task<IEnumerable<object>> GetBossInformation();
        Task<IEnumerable<object>> GetNonSalesRepresentatives();
        Task<IEnumerable<object>> GetEmployeeBossInformation();
        Task<IEnumerable<object>> GetEmployeeHierarchy();
        Task<IEnumerable<object>> GetEmployeesWithoutClient();
        Task<IEnumerable<object>> GetEmployeesWithoutOffice();
        Task<IEnumerable<object>> GetEmployeesWithoutClientAndOffice();
        Task<IEnumerable<object>> GetEmployeesWithoutClientsAndBoss();
        Task<IEnumerable<object>> GetEmployeesWithoutClients();
        

    }
}