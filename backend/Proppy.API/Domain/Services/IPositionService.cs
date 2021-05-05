using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;

namespace Proppy.API.Domain.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> ListAsync();
    }
}