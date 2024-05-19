using Crm.Application.ViewModel;
using Crm.Application.UseCases.SubstatusUseCases;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubstatusController : ControllerBase
{
    private readonly ISubstatusRepository _repository;

    public SubstatusController(ISubstatusRepository repository)
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
    public IActionResult Post([FromBody] SubstatusVM dTO, [FromServices] CreateSubtatusUseCase useCase)
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
