using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Services;
using Proppy.API.Domain.Repositories;
using Proppy.API.Domain.Communication;
using System;

namespace Proppy.API.Services
{
    public class PositionService: IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PositionService(IPositionRepository positionRepository, IUnitOfWork unitOfWork)
        {
            _positionRepository = positionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Position>> ListAsync()
        {
            return await _positionRepository.ListAsync();
        }

        public async Task<SavePositionResponse> SaveAsync(Position position)
        {
            try
            {
                await _positionRepository.AddAsync(position);
                await _unitOfWork.CompleteAsync();

                return new SavePositionResponse(position);
            }
            catch (Exception ex)
            {
                // Add logging here
                return new SavePositionResponse($"An error occurred when saving the position: {ex.Message}");
            }
        }
    }
}