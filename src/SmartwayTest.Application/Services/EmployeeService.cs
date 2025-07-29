using SmartwayTest.Application.Mappers;
using SmartwayTest.Contracts.DTOs;
using SmartwayTest.Contracts.Requests;
using SmartwayTest.DataAccess.Repositories;
using SmartwayTest.Domain.Entities;
using SmartwayTest.Domain.Exceptions.Company;
using SmartwayTest.Domain.Exceptions.Department;
using SmartwayTest.Domain.Exceptions.Passport;
using SmartwayTest.Domain.Repositories;

namespace SmartwayTest.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPassportRepository _passportRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public EmployeeService(
        IEmployeeRepository employeeRepository, 
        IPassportRepository passportRepository, 
        ICompanyRepository companyRepository, 
        IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _passportRepository = passportRepository;
        _companyRepository = companyRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<int> AddEmployeeAsync(CreateEmployeeRequest request)
    {
        var isPassportExists = await _passportRepository.IsPassportByIdExistsAsync(request.PassportId);
        if (!isPassportExists) throw new PassportNotFoundException(request.PassportId);

        var isCompanyExists = await _companyRepository.IsCompanyByIdExistsAsync(request.CompanyId);
        if (!isCompanyExists) throw new CompanyNotFoundException(request.CompanyId);

        var isDepartmentExists = await _departmentRepository.IsDepartmentByIdExistsAsync(request.DepartmentId);
        if (!isDepartmentExists) throw new DepartmentNotFoundException(request.DepartmentId);

        var employeeId = await _employeeRepository.AddEmployeeAsync(request.MapToEntity());
        return employeeId;
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        await _employeeRepository.DeleteEmployeeAsync(employeeId);
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesByCompanyIdAsync(int companyId)
    {
        var isCompanyExists = await _companyRepository.IsCompanyByIdExistsAsync(companyId);
        if (!isCompanyExists) throw new CompanyNotFoundException(companyId);

        var employees = await _employeeRepository.GetEmployeesByCompanyIdAsync(companyId);
        return employees.Select(e => e.MapToDto());
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesByDepartmentIdAsync(int companyId, int departmentId)
    {
        var isCompanyExists = await _companyRepository.IsCompanyByIdExistsAsync(companyId);
        if (!isCompanyExists) throw new CompanyNotFoundException(companyId);

        var isDepartmentExists = await _departmentRepository.IsDepartmentByIdExistsAsync(departmentId);
        if (!isDepartmentExists) throw new DepartmentNotFoundException(departmentId);

        var employees = await _employeeRepository.GetEmployeesByDepartmentIdAsync(departmentId);
        return employees.Select(e => e.MapToDto());
    }

    public async Task UpdateEmployeeAsync(UpdateEmployeeRequest updateEmployeeRequest)
    {
        await _employeeRepository.UpdateEmployeeAsync(updateEmployeeRequest.MapToEntity());
    }
}
