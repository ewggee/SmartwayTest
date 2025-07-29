using SmartwayTest.Contracts.DTOs;
using SmartwayTest.Contracts.Requests;

namespace SmartwayTest.Application.Services;
public interface IEmployeeService
{
    Task<int> AddEmployeeAsync(CreateEmployeeRequest createEmployeeRequest);
    Task DeleteEmployeeAsync(int employeeId);
    Task<IEnumerable<EmployeeDto>> GetEmployeesByCompanyIdAsync(int companyId);
    Task<IEnumerable<EmployeeDto>> GetEmployeesByDepartmentIdAsync(int departmentId);
    Task UpdateEmployeeAsync(UpdateEmployeeRequest updateEmployeeRequest);
}