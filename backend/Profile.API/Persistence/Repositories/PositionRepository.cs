using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profile.API.Domain.Models;
using Profile.API.Domain.Repositories;
using Profile.API.Persistence.Contexts;


namespace Profile.API.Persistence.Repositories
{
    public class PositionRepository: BaseRepository, IPositionRepository
    {
        public PositionRepository(AppDbContext context): base(context)
        {
        }

        public async Task<IEnumerable<Position>> ListAsync()
        {
            return await _context.Positions.ToListAsync();
        }
    }
}