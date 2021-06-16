using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Registration.Models;

namespace Registration.Contract
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees();
    }
}
