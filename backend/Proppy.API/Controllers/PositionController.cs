using Microsoft.AspNetCore.Mvc;
using Proppy.API.Domain.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Proppy.API.Domain.Models;
using AutoMapper;
using Proppy.API.Resources;
using Proppy.API.Extensions;
using Microsoft.AspNetCore.Cors;

namespace Proppy.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePositionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var position = _mapper.Map<SavePositionResource, Position>(resource);
            var result = await _positionService.SaveAsync(position);

            if (!result.Success)
                return BadRequest(result.Message);

            var positionResource = _mapper.Map<Position, PositionResource>(result.Position);
            return Ok(positionResource);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> PutAsync(string code, [FromBody] UpdatePositionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var position = _mapper.Map<UpdatePositionResource, Position>(resource);
            var result = await _positionService.UpdateAsync(code, position);

            if (!result.Success)
                return BadRequest(result.Message);

            var positionResource = _mapper.Map<Position, PositionResource>(result.Position);
            return Ok(positionResource);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteAsync(string code)
        {
            var result = await _positionService.DeleteAsync(code);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var positionResource = _mapper.Map<Position, PositionResource>(result.Position);
            return Ok(positionResource);
        }
    }
}