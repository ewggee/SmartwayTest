using Microsoft.AspNetCore.Mvc;
using SmartwayTest.Contracts.Requests;
using SmartwayTest.Contracts.Services;

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

    [HttpPatch("{employeeId}")]
    public async Task<IActionResult> UpdateEmployee([FromRoute] int employeeId, [FromBody] UpdateEmployeeRequest request)
    {
        await _employeeService.UpdateEmployeeAsync(employeeId, request);

        return NoContent();
    }
}
