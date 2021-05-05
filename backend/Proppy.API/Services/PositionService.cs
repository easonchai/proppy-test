using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Services;
using Proppy.API.Domain.Repositories;

namespace Proppy.API.Services
{
    public class PositionService: IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<IEnumerable<Position>> ListAsync()
        {
            return await _positionRepository.ListAsync();
        }
    }
}