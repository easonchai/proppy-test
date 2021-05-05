using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Communication;

namespace Proppy.API.Domain.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> ListAsync();
        Task<SavePositionResponse> SaveAsync(Position position);
    }
}