using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartwayTest.Application.Services;

namespace SmartwayTest.Api.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public CompanyController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    [HttpGet("{companyId}/employees")]
    public async Task<IActionResult> GetEmployeesByCompanyId([FromRoute] int companyId)
    {
        var employees = await _employeeService.GetEmployeesByCompanyIdAsync(companyId);

        return Ok(employees);
    }

    [HttpGet("{companyId}/departments/{departmentId}/employees")]
    public async Task<IActionResult> GetEmployeesByDepartmentId([FromRoute] int companyId, [FromRoute] int departmentId)
    {
        var employees = await _employeeService.GetEmployeesByDepartmentIdAsync(companyId, departmentId);

        return Ok(employees);
    }
}
