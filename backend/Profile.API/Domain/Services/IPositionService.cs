using System.Collections.Generic;
using System.Threading.Tasks;
using Profile.API.Domain.Models;

namespace Profile.API.Domain.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> ListAsync();
    }
}