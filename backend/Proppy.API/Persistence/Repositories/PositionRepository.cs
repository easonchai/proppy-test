using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Repositories;
using Proppy.API.Persistence.Contexts;


namespace Proppy.API.Persistence.Repositories
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

        public async Task AddAsync(Position position)
        {
            await _context.Positions.AddAsync(position);
        }

        public async Task<Position> FindByCodeAsync(string code)
        {
            return await _context.Positions.FindAsync(code);
        }

        public void Update(Position position)
        {
            _context.Positions.Update(position);
        }
    }
}