using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Communication;
using Proppy.API.Domain.Models.Queries;

namespace Proppy.API.Domain.Services
{
    public interface IEmployeeService
    {
        Task<QueryResult<Employee>> ListAsync(EmployeesQuery query);
        Task<Employee> GetByIdAsync(long id);
        Task<EmployeeResponse> SaveAsync(Employee employee);
        Task<EmployeeResponse> UpdateAsync(long id, Employee employee);
        Task<EmployeeResponse> DeleteAsync(long id);
    }
}