using SmartwayTest.Application.Mappers;
using SmartwayTest.Contracts.DTOs;
using SmartwayTest.Contracts.Requests;
using SmartwayTest.Contracts.Services;
using SmartwayTest.Domain.Entities;
using SmartwayTest.Domain.Exceptions.Company;
using SmartwayTest.Domain.Exceptions.Department;
using SmartwayTest.Domain.Exceptions.Employee;
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
        _employeeRepository.BeginTransaction();
        try
        {
            var isPassportExists = await _passportRepository.IsPassportExistsAsync(request.Passport.MapToEntity());
            if (isPassportExists) throw new PassportAlreadyExistsException(request.Passport.Number);

            var isCompanyExists = await _companyRepository.IsCompanyByIdExistsAsync(request.CompanyId);
            if (!isCompanyExists) throw new CompanyNotFoundException(request.CompanyId);

            var isDepartmentExists = await _departmentRepository.IsDepartmentByIdExistsAsync(request.DepartmentId);
            if (!isDepartmentExists) throw new DepartmentNotFoundException(request.DepartmentId);

            var passport = new Passport
            {
                Type = request.Passport.Type,
                Number = request.Passport.Number
            };
            var passportId = await _passportRepository.AddPassportAsync(passport);

            var employee = request.MapToEntity();
            employee.PassportId = passportId;
            var employeeId = await _employeeRepository.AddEmployeeAsync(employee);

            _employeeRepository.Commit();

            return employeeId;
        }
        catch
        {
            _employeeRepository.Rollback();
            throw;
        }
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

    public async Task UpdateEmployeeAsync(int employeeId, UpdateEmployeeRequest request)
    {
        _employeeRepository.BeginTransaction();
        try
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(employeeId)
            ?? throw new EmployeeNotFoundException(employeeId);

            var isPassportExists = await _passportRepository.IsPassportExistsAsync(request.Passport.MapToEntity());
            if (!isPassportExists) throw new PassportNotFoundException();

            var isCompanyExists = await _companyRepository.IsCompanyByIdExistsAsync(request.CompanyId);
            if (!isCompanyExists) throw new CompanyNotFoundException(request.CompanyId);

            var isDepartmentExists = await _departmentRepository.IsDepartmentByIdExistsAsync(request.DepartmentId);
            if (!isDepartmentExists) throw new DepartmentNotFoundException(request.DepartmentId);

            await _passportRepository.UpdatePassportAsync(request.Passport.MapToEntity());

            var employee = request.MapToEntity();
            employee.Id = employeeId;
            await _employeeRepository.UpdateEmployeeAsync(employee);

            _employeeRepository.Commit();
        }
        catch
        {
            _employeeRepository.Rollback();
            throw;
        }
    }
}
