using Crm.Application.UseCases.MotivoUseCase;
using Crm.Application.ViewModel.Motivo;
using Crm.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MotivoController : ControllerBase
{
    private readonly IMotivoRepository _repository;

    public MotivoController(IMotivoRepository repository)
        => _repository = repository;

    [HttpGet]
    [Route("getall")]
    public IActionResult Get()
    {
        try
        {
            return Ok(_repository.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error has occurred. {ex.Message}");
        }

    }

    [HttpPost]
    [Route("create")]
    public IActionResult Post([FromBody] MotivoVM dTO, [FromServices] CreateMotivoUseCase useCase)
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
