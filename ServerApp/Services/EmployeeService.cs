using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.DataAccess;
using ServerApp.Models;

namespace ServerApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly SqlDbContext _dbContext;

        public EmployeeService(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.Include(x => x.Citizenship).Include(x => x.City).Include(x => x.FamilyPosition).Include(x => x.Disability).ToListAsync();
        }
        public async Task CreateEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> SingleEmployee(string id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }
        public async Task<bool> EditEmployee(string id, Employee employee)
        {
            if (id != employee.Id)
            {
                return false;
            }

            _dbContext.Entry(employee).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployee(string id)
        {
            var patient = await _dbContext.Employees.FindAsync(id);
            if (patient == null)
            {
                return false;
            }

            _dbContext.Employees.Remove(patient);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool CheckIfPassportExist(Employee user)
        {
            var users = _dbContext.Employees;
            return users.Any(x => (x.PassportSeries + x.PassportNumber == user.PassportSeries + user.PassportNumber || x.IdentityNumber == user.IdentityNumber) && x.Id != user.Id);
        }

        public Info GetCreationInfo()
        {
            return new Info()
            {
                Citizenships = _dbContext.Citizenship.ToList(),
                Disabilities = _dbContext.Disability.ToList(),
                Cities = _dbContext.City.ToList(),
                FamilyPositions = _dbContext.FamilyPosition.ToList()
            };
        }
    }
}
