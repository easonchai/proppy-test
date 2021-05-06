using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;

namespace Proppy.API.Domain.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> ListAsync();
        Task AddAsync(Position position);
        Task<Position> FindByCodeAsync(string code);
        void Update(Position position);
    }
}