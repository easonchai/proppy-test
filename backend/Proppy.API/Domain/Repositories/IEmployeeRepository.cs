using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Models.Queries;

namespace Proppy.API.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<QueryResult<Employee>> ListAsync(EmployeesQuery query);
        Task AddAsync(Employee employee);
        Task<Employee> FindByIdAsync(long id);
        void Update(Employee employee);
        void Remove(Employee employee);
    }
}