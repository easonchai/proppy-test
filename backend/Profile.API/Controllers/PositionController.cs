using Microsoft.AspNetCore.Mvc;
using Profile.API.Domain.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Profile.API.Domain.Models;

namespace Profile.API.Controllers
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