using SmartwayTest.Contracts.Dapper;
using SmartwayTest.DataAccess.Scripts;
using SmartwayTest.Domain.Entities;
using SmartwayTest.Domain.Repositories;

namespace SmartwayTest.DataAccess.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDapperContext _context;

    public EmployeeRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<int> AddEmployeeAsync(Employee employee)
    {
        var id = await _context.ExecuteWithResult<int>(new QueryObject(
            Sql.CreateEmployee,
            new {
                name = employee.Name,
                surname = employee.Surname,
                phone = employee.Phone,
                company_id = employee.CompanyId,
                passport_id = employee.PassportId,
                department_id = employee.DepartmentId
            }));

        return id;
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        await _context.Execute(new QueryObject(
            Sql.DeleteEmployee,
            new { id = employeeId }));
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(int companyId)
    {
        var employees = await _context.ListOrEmpty<Employee>(new QueryObject(
            Sql.GetEmployeesByCompanyId,
            new { company_id = companyId }));

        return employees;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
    {
        var employees = await _context.ListOrEmpty<Employee>(new QueryObject(
            Sql.GetEmployeesByDepartmentId,
            new { department_id = departmentId }));

        return employees;
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        await _context.Execute(new QueryObject(
            Sql.UpdateEmployee,
            new { id = employee.Id }));
    }
}
