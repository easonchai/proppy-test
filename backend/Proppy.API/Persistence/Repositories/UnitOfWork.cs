using Proppy.API.Domain.Repositories;
using System.Threading.Tasks;
using Proppy.API.Persistence.Contexts;

namespace Proppy.API.Persistence.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}