using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Services;
using Proppy.API.Resources;

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
        public async Task<IEnumerable<EmployeeResource>> ListAsync()
        {
            var employees = await _employeeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees);

            return resources;
        }

        [HttpPost]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody])
        {
            var employees = await _employeeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees);

            return resources;
        }
    }
}