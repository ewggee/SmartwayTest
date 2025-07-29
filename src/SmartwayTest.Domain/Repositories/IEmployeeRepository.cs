using SmartwayTest.Domain.Entities;

namespace SmartwayTest.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<int> AddEmployeeAsync(Employee employee);
    Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(int companyId);
    Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int employeeId);
}
