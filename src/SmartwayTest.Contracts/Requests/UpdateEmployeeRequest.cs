using SmartwayTest.Contracts.Attributes;
using SmartwayTest.Contracts.DTOs;

namespace SmartwayTest.Contracts.Requests;

public class UpdateEmployeeRequest
{
    [RequiredField]
    public string Name { get; set; }

    [RequiredField]
    public string Surname { get; set; }

    [RequiredField]
    [FormattedPhoneField]
    public string Phone { get; set; }

    [RequiredField]
    [RangeField(min: 1, max: int.MaxValue)]
    public int CompanyId { get; set; }

    [RequiredField]
    public PassportDto Passport { get; set; }

    [RequiredField]
    [RangeField(min: 1, max: int.MaxValue)]
    public int DepartmentId { get; set; }
}
