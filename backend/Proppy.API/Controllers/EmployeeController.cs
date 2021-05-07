using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Services;
using Proppy.API.Resources;
using Proppy.API.Extensions;
using Proppy.API.Domain.Models.Queries;
using Microsoft.AspNetCore.Cors;
namespace Proppy.API.Controllers
{
    [Route("/api/[controller]")]
    public class EmployeeController: Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<QueryResultResource<EmployeeResource>> ListAsync([FromQuery] EmployeeQueryResource query)
        {
            var employeesQuery = _mapper.Map<EmployeeQueryResource, EmployeesQuery>(query);
            var queryResult = await _employeeService.ListAsync(employeesQuery);

            var resources = _mapper.Map<QueryResult<Employee>, QueryResultResource<EmployeeResource>>(queryResult);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeResource> GetAsync(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            var resource = _mapper.Map<Employee, EmployeeResource>(employee);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.SaveAsync(employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(employeeResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.UpdateAsync(id, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(employeeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(employeeResource);
        }
    }
}