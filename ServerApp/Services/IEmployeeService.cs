using System.Collections.Generic;
using System.Threading.Tasks;
using ServerApp.Models;

namespace ServerApp.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task CreateEmployee(Employee employee);
        Task<bool> EditEmployee(string id, Employee employee);
        Task<Employee> SingleEmployee(string id);
        Task<bool> DeleteEmployee(string id);
        Info GetCreationInfo();
    }
}
