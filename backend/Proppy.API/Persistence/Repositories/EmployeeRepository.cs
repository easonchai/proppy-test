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
    }
}