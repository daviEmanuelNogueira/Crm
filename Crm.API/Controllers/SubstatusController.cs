using Crm.Application.DTOs.Substatus;
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
