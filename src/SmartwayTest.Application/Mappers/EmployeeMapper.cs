using SmartwayTest.Contracts.DTOs;
using SmartwayTest.Contracts.Requests;
using SmartwayTest.Domain.Entities;

namespace SmartwayTest.Application.Mappers;

public static class EmployeeMapper
{
    public static Employee MapToEntity(this CreateEmployeeRequest r)
    {
        return new Employee
        {
            Name = r.Name,
            Surname = r.Surname,
            Phone = r.Phone,
            CompanyId = r.CompanyId,
            DepartmentId = r.DepartmentId,
            PassportId = r.PassportId,
        };
    }

    public static Employee MapToEntity(this UpdateEmployeeRequest r)
    {
        return new Employee
        {
            Name = r.Name,
            Surname = r.Surname,
            Phone = r.Phone,
            CompanyId = r.CompanyId,
            DepartmentId = r.DepartmentId,
            PassportId = r.PassportId,
        };
    }

    public static EmployeeDto MapToDto(this Employee e)
    {
        return new EmployeeDto
        {
            Id = e.Id,
            Name = e.Name,
            Surname = e.Surname,
            Phone = e.Phone,
            CompanyId = e.CompanyId,
            PassportId = e.PassportId,
            DepartmentId = e.DepartmentId
        };
    }
}
