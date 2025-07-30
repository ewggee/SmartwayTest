using SmartwayTest.Domain.Entities;
using SmartwayTest.Domain.QueryModels;

namespace SmartwayTest.Domain.Repositories;

public interface IEmployeeRepository : ITransactionable
{
    Task<EmployeeFullInfo?> GetEmployeeByIdAsync(int employeeId);
    Task<IEnumerable<EmployeeFullInfo>> GetEmployeesByCompanyIdAsync(int companyId);
    Task<IEnumerable<EmployeeFullInfo>> GetEmployeesByDepartmentIdAsync(int companyId, int departmentId);
    Task<int> AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int employeeId);
}
