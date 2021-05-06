using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;

namespace Proppy.API.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task AddAsync(Employee employee);
        Task<Employee> FindByIdAsync(int id);
        void Update(Employee employee);
        void Remove(Employee employee);
    }
}