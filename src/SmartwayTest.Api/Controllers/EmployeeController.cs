using Microsoft.AspNetCore.Mvc;
using SmartwayTest.Application.Services;
using SmartwayTest.Contracts.Requests;

namespace SmartwayTest.Api.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] CreateEmployeeRequest createEmployeeRequest)
    {
        var id = await _employeeService.AddEmployeeAsync(createEmployeeRequest);

        return Ok(id);
    }

    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> DeleteEmployee([FromRoute] int employeeId)
    {
        await _employeeService.DeleteEmployeeAsync(employeeId);

        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest updateEmployeeRequest)
    {
        await _employeeService.UpdateEmployeeAsync(updateEmployeeRequest);

        return NoContent();
    }
}
