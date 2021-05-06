using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Repositories;
using Proppy.API.Persistence.Contexts;

namespace Proppy.API.Persistence.Repositories
{
    public class EmployeeRepository: BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context): base(context)
        {
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _context.Employees.Include(e => e.Position)
                                            .ToListAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task<Employee> FindByIdAsync(int code)
        {
            return await _context.Employees.FindAsync(code);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
    }
}