using System.Collections.Generic;
using System.Threading.Tasks;
using Registration.Dto;
using Registration.Models;

namespace Registration.Contract
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> SelectAll();

        public Task<Employee> SelectById(int id);

        public Task<Employee> Insert(CreateEmployeeDto employee);

        public Task Update(int id, EditEmployeeDto employee);

        public Task DeleteById(int id);

        public Task<IEnumerable<Employee>> Include();
    }
}
