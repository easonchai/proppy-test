using Microsoft.AspNetCore.Mvc;
using Proppy.API.Domain.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Proppy.API.Domain.Models;

namespace Proppy.API.Controllers
{
    [Route("/api/[controller]")]
    public class PositionController: Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            var positions = await _positionService.ListAsync();
            return positions;
        }
    }
}