using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Communication;

namespace Proppy.API.Domain.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> ListAsync();
        Task<PositionResponse> SaveAsync(Position position);
        Task<PositionResponse> UpdateAsync(string Code, Position position);
        Task<PositionResponse> DeleteAsync(string code);
    }
}