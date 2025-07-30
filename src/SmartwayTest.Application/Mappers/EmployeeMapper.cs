using SmartwayTest.Contracts.DTOs;
using SmartwayTest.Contracts.Requests;
using SmartwayTest.Domain.Entities;
using SmartwayTest.Domain.QueryModels;

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
            Passport = new Passport
            {
                Type = r.Passport.Type,
                Number = r.Passport.Number
            }
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
        };
    }

    public static EmployeeDto MapToDto(this EmployeeFullInfo source)
    {
        return new EmployeeDto
        {
            Id = source.Id,
            Name = source.Name,
            Surname = source.Surname,
            Phone = source.Phone,
            CompanyId = source.CompanyId,
            Passport = new PassportDto
            {
                Type = source.PassportType,
                Number = source.PassportNumber
            },
            Department = new DepartmentDto
            {
                Name = source.DepartmentName,
                Phone = source.DepartmentPhone
            }
        };
    }
}
