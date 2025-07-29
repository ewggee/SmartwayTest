using SmartwayTest.Application.Mappers;
using SmartwayTest.Contracts.DTOs;
using SmartwayTest.Contracts.Requests;
using SmartwayTest.Domain.Repositories;

namespace SmartwayTest.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> AddEmployeeAsync(CreateEmployeeRequest createEmployeeRequest)
    {
        //todo: Добавить проверки на passportId, companyId, departmentId
        var id = await _employeeRepository.AddEmployeeAsync(createEmployeeRequest.MapToEntity());

        return id;
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        await _employeeRepository.DeleteEmployeeAsync(employeeId);
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesByCompanyIdAsync(int companyId)
    {
        var employees = await _employeeRepository.GetEmployeesByCompanyIdAsync(companyId);

        return employees.Select(e => e.MapToDto());
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesByDepartmentIdAsync(int departmentId)
    {
        var employees = await _employeeRepository.GetEmployeesByDepartmentIdAsync(departmentId);

        return employees.Select(e => e.MapToDto());
    }

    public async Task UpdateEmployeeAsync(UpdateEmployeeRequest updateEmployeeRequest)
    {
        await _employeeRepository.UpdateEmployeeAsync(updateEmployeeRequest.MapToEntity());
    }
}
