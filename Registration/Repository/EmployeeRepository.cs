using Dapper;
using Registration.Context;
using Registration.Contract;
using Registration.Dto;
using Registration.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _ctx;

        public EmployeeRepository(DapperContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Employee>> SelectAll()
        {
            string query = "SELECT * FROM Employees";
            using (var connection = _ctx.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
        }

        public async Task<Employee> Insert(CreateEmployeeDto employee)
        {
            string query = "INSERT INTO " +
                                "Employees (SurName, Name, Patronymic, EmploymentDate, Position, CompanyId) " +
                            "VALUES " +
                                 "(@SurName, @Name, @Patronymic, @EmploymentDate, @Position, @CompanyId) " +
                            "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("SurName", employee.SurName, DbType.String);
            parameters.Add("Patronymic", employee.Patronymic, DbType.String);
            parameters.Add("EmploymentDate", employee.EmploymentDate, DbType.DateTime);
            parameters.Add("Position", employee.Position, DbType.Int32);
            parameters.Add("CompanyId", employee.CompanyId, DbType.Int32);

            using (var connection = _ctx.CreateConnection())
            {
                int id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdEmployee = new Employee
                {
                    Id = id,
                    Name = employee.Name,
                    SurName = employee.SurName,
                    Patronymic = employee.Patronymic,
                    EmploymentDate = employee.EmploymentDate,
                    Position = employee.Position,
                    CompanyId = employee.CompanyId,

                };
                return createdEmployee;
            }
        }

        public async Task<Employee> SelectById(int id)
        {
            var query = "SELECT * FROM " +
                            "Employees " +
                        "WHERE " +
                            "Id = @Id";

            using (var connection = _ctx.CreateConnection())
            {
                var employee = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { id });
                return employee;
            }
        }

        public async Task Update(int id, EditEmployeeDto employee)
        {
            string query = "UPDATE " +
                                "Employees " +
                            "SET " +
                                "Name = @Name, SurName = @SurName, Patronymic = @Patronymic, EmploymentDate = @EmploymentDate, Position = @Position, CompanyId = @CompanyId " +
                             "WHERE " +
                                "Id = @Id";

            var parameters = new DynamicParameters();

            parameters.Add("Id", employee.Id, DbType.Int32);
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("SurName", employee.SurName, DbType.String);
            parameters.Add("Patronymic", employee.Patronymic, DbType.String);
            parameters.Add("EmploymentDate", employee.EmploymentDate, DbType.DateTime);
            parameters.Add("Position", employee.Position, DbType.Int32);
            parameters.Add("CompanyId", employee.CompanyId, DbType.Int32);

            using (var connection = _ctx.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteById(int id)
        {
            string query = "DELETE FROM " +
                                "Employees " +
                            "WHERE " +
                                "Id = @Id";
            using (var connection = _ctx.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<Employee>> Include()
        {
            string query = "SELECT " +
                                "[u].*, [c].[Id], [c].[Name], [c].[Form] " +
                            "FROM " +
                                "[Employees] AS [u] " +
                            "LEFT JOIN " +
                                "[Companies] AS [c] " +
                            "ON " +
                                "[u].[CompanyId] = [c].[Id]";

            using (var connection = _ctx.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee, Company, Employee>(query, (u, c1) =>
                {
                    u.Company = new Company { Id = c1.Id, Name = c1.Name, Form = c1.Form};
                    return u;
                });
                return employees;
            }
        }
    }
}
