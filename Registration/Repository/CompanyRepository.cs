using Dapper;
using Registration.Context;
using Registration.Contract;
using Registration.Dto;
using Registration.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _ctx;

        public CompanyRepository(DapperContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Company>> SelectAll()
        {
            string query = "SELECT * FROM Companies";
            using (var connection = _ctx.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }

        public async Task<Company> SelectById(int id)
        {
            var query = "SELECT * FROM " +
                            "Companies " +
                        "WHERE " +
                            "Id = @Id";

            using (var connection = _ctx.CreateConnection())
            {
                var companies = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
                return companies;
            }
        }

        public async Task<Company> Insert(CreateCompanyDto company)
        {
            string query = "INSERT INTO " +
                                "Companies (Name, Form) " +
                            "VALUES " +
                                 "(@Name, @Form) " +
                            "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", company.Name, DbType.String);
            parameters.Add("Form", company.Form, DbType.String);

            using (var connection = _ctx.CreateConnection())
            {
                int id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdCompany = new Company
                {
                    Id = id,
                    Name = company.Name,
                    Form = company.Form,
                };
                return createdCompany;
            }
        }

        public async Task Update(int id, EditCompanyDto company)
        {
            string query = "UPDATE " +
                                "Companies " +
                            "SET " +
                                "Name = @Name, Form = @Form " +
                             "WHERE " +
                                "Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", company.Id, DbType.Int32);
            parameters.Add("Name", company.Name, DbType.String);
            parameters.Add("Form", company.Form, DbType.String);

            using (var connection = _ctx.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteById(int id)
        {
            string query = "DELETE FROM " +
                                "Companies " +
                            "WHERE " +
                                "Id = @Id";
            using (var connection = _ctx.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public Task<IEnumerable<Company>> Include() => throw new NotImplementedException();
    }
}
