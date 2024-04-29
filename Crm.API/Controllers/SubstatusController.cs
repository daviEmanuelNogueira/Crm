using Crm.Application.DTOs.Substatus;
using Crm.Application.UseCases.SubstatusUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubstatusController : ControllerBase
{
    [HttpPost]
    [Route("create")]
    public IActionResult Post([FromBody] CreateSubstatusDTO dTO, [FromServices] CreateSubtatusUseCase useCase)
    {
        try
        {
            useCase.Execute(dTO);
            return Created(string.Empty, null);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error has occurred. {ex.Message}");
        }
    }
}
