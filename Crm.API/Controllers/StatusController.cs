using Crm.Application.UseCases.StatusUseCases;
using Crm.Application.ViewModel;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    private readonly IStatusRepository _repository;

    public StatusController(IStatusRepository repository)
        => _repository = repository;

    [HttpGet]
    [Route("getall")]
    public IActionResult Get()
    {
        try
        {
            var response = _repository.GetAll();
            return Ok(new { response });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error has occurred. {ex.Message}");
        }

    }

    [HttpPost]
    [Route("create")]
    public IActionResult Post([FromBody] StatusVM dTO, [FromServices] CreateStatusUseCase useCase)
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
