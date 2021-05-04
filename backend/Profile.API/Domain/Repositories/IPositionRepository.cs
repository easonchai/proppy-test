using System.Collections.Generic;
using System.Threading.Tasks;
using Profile.API.Domain.Models;

namespace Profile.API.Domain.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> ListAsync();
    }
}