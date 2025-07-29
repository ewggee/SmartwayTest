using SmartwayTest.Contracts.Dapper;
using SmartwayTest.DataAccess.Scripts;
using SmartwayTest.Domain.Entities;
using SmartwayTest.Domain.QueryModels;
using SmartwayTest.Domain.Repositories;

namespace SmartwayTest.DataAccess.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDapperContext _context;

    public EmployeeRepository(IDapperContext context)
    {
        _context = context;
    }

    public void BeginTransaction() => _context.BeginTransaction();

    public void Commit() => _context.Commit();

    public void Rollback() => _context.Rollback();

    public async Task<EmployeeFullInfo?> GetEmployeeByIdAsync(int employeeId)
    {
        var employee = await _context.FirstOrDefault<EmployeeFullInfo>(new QueryObject(
            Sql.GetEmployeeById,
            new { id = employeeId }));

        return employee;
    }

    public async Task<IEnumerable<EmployeeFullInfo>> GetEmployeesByCompanyIdAsync(int companyId)
    {
        var employees = await _context.ListOrEmpty<EmployeeFullInfo>(new QueryObject(
            Sql.GetEmployeesByCompanyId,
            new { company_id = companyId }));

        return employees;
    }

    public async Task<IEnumerable<EmployeeFullInfo>> GetEmployeesByDepartmentIdAsync(int departmentId)
    {
        var employees = await _context.ListOrEmpty<EmployeeFullInfo>(new QueryObject(
            Sql.GetEmployeesByDepartmentId,
            new { department_id = departmentId }));

        return employees;
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

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        await _context.Execute(new QueryObject(
            Sql.UpdateEmployee,
            new { name = employee.Name, surname = employee.Surname, phone = employee.Phone,
                company_id = employee.CompanyId, department_id = employee.DepartmentId, id = employee.Id }));
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        await _context.Execute(new QueryObject(
            Sql.DeleteEmployee,
            new { id = employeeId }));
    }
}
