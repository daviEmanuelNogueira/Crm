using Crm.Application.Requests;
using Crm.Application.UseCases.StatusSubstatusUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusSubstatusController : ControllerBase
{
    [HttpGet]
    [Route("getall")]
    public IActionResult Get([FromServices] GetAllStatusSubstatusUseCase useCase)
    {
        try
        {
            var response = useCase.Execute();
            return Ok(new { response });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error has occurred: {ex.Message}");
        }
    }

    [HttpPost]
    [Route("crate")]
    public IActionResult Post([FromBody] CreateStatusSubstatusRequestVM request, [FromServices] CreateStatusSubstatusUseCase useCase)
    {
        try
        {
            useCase.Execute(request);
            return Created(string.Empty, null);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error has occurred: {ex.Message}");
        }
    }
}
