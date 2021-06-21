using Dapper;
using Registration.Context;
using Registration.Contract;
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

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            string query = "SELECT * FROM Companies";
            using (var connection = _ctx.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }

        public async Task<Company> GetCompany(int id)
        {
            string query = "SELECT * FROM " +
                                "Companies " +
                            "WHERE " +
                                "Id = @Id";

            using (var connection = _ctx.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });

                return company;
            }
        }


        public async Task<Company> GetCompanyByEmployeeId(int id)
        {
            var procedureName = "ShowCompanyForProvidedEmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);
            using (var connection = _ctx.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<Company>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return company;
            }
        }
    }
}
