using Crm.Application.UseCases.AtendimentoUseCase;
using Crm.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AtendimentoController : ControllerBase
{
    [HttpPost]
    public IActionResult NovoAtendimento([FromBody] AtendimentoVM atendimento, [FromServices] CreateAtendimentoUseCase useCase)
    {
		try
		{
            useCase.Execute(atendimento);
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
