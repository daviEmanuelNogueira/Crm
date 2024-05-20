using Crm.Application.Requests;
using Crm.Application.UseCases.StatusSubstatusUseCase;
using Crm.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusSubstatusController : ControllerBase
{
    private readonly IStatusSubstatusRepository _statusSubstatusRepository;

    public StatusSubstatusController(IStatusSubstatusRepository statusSubstatusRepository)
    {
        _statusSubstatusRepository = statusSubstatusRepository;
    }

    [HttpGet]
    [Route("getall")]
    public IActionResult Get([FromServices] GetAllStatusSubstatusUseCase useCase)
    {
        try
        {
            return Ok(useCase.Execute());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error has occurred: {ex.Message}");
        }
    }

    [HttpGet]
    [Route("getbystatus/{statusId}")]
    public IActionResult Getbystatus(int statusId)
    {
        try
        {
            return Ok(_statusSubstatusRepository.ObterSubstatusComStatusId(statusId));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error has occurred: {ex.Message}");
        }
    }

    [HttpGet]
    [Route("getstatussubstatusid/{statusId}/{substatusId}")]
    public IActionResult ObeterId(int statusId, int substatusId)
    {
        try
        {
            return Ok(_statusSubstatusRepository.ObterId(statusId, substatusId));
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
