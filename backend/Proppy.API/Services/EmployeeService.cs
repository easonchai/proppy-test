using System.Collections.Generic;
using System.Threading.Tasks;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Repositories;
using Proppy.API.Domain.Services;
using Proppy.API.Domain.Communication;
using System;

namespace Proppy.API.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<EmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.AddAsync(employee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(employee);
            }
            catch (Exception ex)
            {
                return new EmployeeResponse($"An error occurred when saving the employee: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> UpdateAsync(int id, Employee employee)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse($"Employee with ID: {id} not found.");
            
            try
            {
                _employeeRepository.Update(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                return new EmployeeResponse($"An error occurred when updating the employee: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> DeleteAsync(int id)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse($"Employee with ID: {id} not found.");
            
            try
            {
                _employeeRepository.Remove(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                return new EmployeeResponse($"An error occurred when deleting the employee: {ex.Message}");
            }   
        }
    }
}