using Microsoft.AspNetCore.Mvc;
using Proppy.API.Domain.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Proppy.API.Domain.Models;
using AutoMapper;
using Proppy.API.Resources;

namespace Proppy.API.Controllers
{
    [Route("/api/[controller]")]
    public class PositionController: Controller
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PositionResource>> GetAllAsync()
        {
            var positions = await _positionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Position>, IEnumerable<PositionResource>>(positions);

            return resources;
        }
    }
}