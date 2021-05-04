using System.Collections.Generic;
using System.Threading.Tasks;
using Profile.API.Domain.Models;
using Profile.API.Domain.Services;
using Profile.API.Domain.Repositories;

namespace Profile.API.Services
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