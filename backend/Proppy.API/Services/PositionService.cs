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
            var existingPosition = await _positionRepository.FindByCodeAsync(position.Code);

            if (existingPosition != null)
                return new SavePositionResponse($"An error occurred when saving the position: Duplicate key of {position.Code} not allowed.");

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

        public async Task<SavePositionResponse> UpdateAsync(string code, Position position)
        {
            var existingPosition = await _positionRepository.FindByCodeAsync(code);

            if (existingPosition == null)
                return new SavePositionResponse($"Position with code {code} not found.");
            
            // Here we update the existing position
            existingPosition.Code = code;
            existingPosition.Description = position.Description;

            try
            {
                _positionRepository.Update(existingPosition);
                await _unitOfWork.CompleteAsync();

                return new SavePositionResponse(existingPosition);
            }
            catch (Exception ex)
            {
                // Log something here
                return new SavePositionResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }
    }
}