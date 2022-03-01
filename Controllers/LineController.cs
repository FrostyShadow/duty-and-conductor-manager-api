using Microsoft.AspNetCore.Mvc;
using DutyAndConductorManager.Api.Services;
using DutyAndConductorManager.Api.Models;

namespace DutyAndConductorManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LineController : ControllerBase
{
    private readonly ILineService _lineService;

    public LineController(ILineService lineService)
    {
        _lineService = lineService;
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var response = await _lineService.GetById(id);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _lineService.GetAll();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddLine([FromBody] AddLineRequest model)
    {
        var response = await _lineService.AddLine(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> EditLine([FromBody] EditLineRequest model)
    {
        var response = await _lineService.EditLine(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteLine([FromBody] DeleteLineRequest model)
    {
        var response = await _lineService.DeleteLine(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }
}