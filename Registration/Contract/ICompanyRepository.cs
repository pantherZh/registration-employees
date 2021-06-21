using Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Contract
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();

        public Task<Company> GetCompanyByEmployeeId(int id);
    }
}
