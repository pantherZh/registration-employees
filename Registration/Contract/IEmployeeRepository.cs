using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Registration.Dto;
using Registration.Models;

namespace Registration.Contract
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task<Employee> CreateEmployee(EmployeeForCreationDto employee);
        public Task UpdateEmployee(int id, EmployeeForEditDto employee);
        public Task DeleteEmployee(int id);
    }
}
