using Crm.Application.DTOs.Status;
using Crm.Application.UseCases.StatusUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    [HttpPost]
    [Route("create")]
    public IActionResult Post([FromBody] CreateStatusDTO dTO, [FromServices] CreateStatusUseCase useCase)
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
