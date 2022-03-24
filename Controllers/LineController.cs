using Microsoft.AspNetCore.Mvc;
using DutyAndConductorManager.Api.Services;
using DutyAndConductorManager.Api.Models;
using Swashbuckle.AspNetCore.Annotations;
using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Produces("application/json")]
public class LineController : ControllerBase
{
    private readonly ILineService _lineService;

    public LineController(ILineService lineService)
    {
        _lineService = lineService;
    }

    [HttpGet]
    [SwaggerOperation("Gets line by it's ID")]
    [ProducesResponseType(typeof(Line), 200)]
    public async Task<IActionResult> GetById([FromQuery, SwaggerParameter("Line ID")] int id)
    {
        var response = await _lineService.GetById(id);

        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of all lines")]
    [ProducesResponseType(typeof(IList<Line>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _lineService.GetAll();

        return Ok(response);
    }

    [HttpPost]
    [SwaggerOperation("Creates new line")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> AddLine([FromBody, SwaggerRequestBody("Line data")] AddLineRequest model)
    {
        var response = await _lineService.AddLine(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Edits existing line")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> EditLine([FromBody, SwaggerRequestBody("Line data")] EditLineRequest model)
    {
        var response = await _lineService.EditLine(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Deletes existing line")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteLine([FromBody, SwaggerRequestBody("Line ID")] DeleteLineRequest model)
    {
        var response = await _lineService.DeleteLine(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }
}