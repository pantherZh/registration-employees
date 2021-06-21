using Registration.Dto;
using Registration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Contract
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> SelectAll();

        public Task<Company> SelectById(int id);

        public Task<Company> Insert(CreateCompanyDto company);

        public Task Update(int id, EditCompanyDto company);

        public Task DeleteById(int id);

        public Task<IEnumerable<Company>> Include();
    }
}
