using Dapper;
using Registration.Context;
using Registration.Contract;
using Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employees";
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
        }
    }
}
