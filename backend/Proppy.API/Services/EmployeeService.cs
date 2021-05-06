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
        private readonly IPositionRepository _positionRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IPositionRepository positionRepository)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _positionRepository = positionRepository;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<Employee> GetByIdAsync(long id)
        {
            return await _employeeRepository.FindByIdAsync(id);
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

        public async Task<EmployeeResponse> UpdateAsync(long id, Employee employee)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);
            var existingPosition = await _positionRepository.FindByCodeAsync(employee.Position_Code);

            if (existingEmployee == null)
                return new EmployeeResponse($"Employee with ID: {id} not found.");

            if (existingPosition == null)
                return new EmployeeResponse($"Position with code: {employee.Position_Code} not found.");

            // Need to find a better way to update, especially large objects
            existingEmployee.Name = employee.Name;
            existingEmployee.Phone_No = employee.Phone_No;
            existingEmployee.Email = employee.Email;
            existingEmployee.Gender = employee.Gender;
            existingEmployee.Position_Code = employee.Position_Code;
            existingEmployee.DOB = employee.DOB;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Remarks = employee.Remarks;
            existingEmployee.Photo = employee.Photo;
            existingEmployee.Position = existingPosition; // This will ensure its getting returned
            
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

        public async Task<EmployeeResponse> DeleteAsync(long id)
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