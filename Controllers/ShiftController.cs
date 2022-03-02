using DutyAndConductorManager.Api.Services;
using DutyAndConductorManager.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DutyAndConductorManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ShiftController : ControllerBase
{
    private readonly IShiftService _shiftService;

    public ShiftController(IShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var response = await _shiftService.GetById(id);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _shiftService.GetAll();

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersInBrigade([FromQuery] int id)
    {
        var response = await _shiftService.GetUsersInBrigade(id);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddBrigade([FromBody] AddBrigadeRequest model)
    {
        var response = await _shiftService.AddBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> EditBrigade([FromBody] EditBrigadeRequest model)
    {
        var response = await _shiftService.EditBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteBrigade([FromBody] DeleteBrigadeRequest model)
    {
        var response = await _shiftService.DeleteBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> AddUserToBrigade([FromBody] AddUserToBrigadeRequest model)
    {
        var response = await _shiftService.AddUserToBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUserFromBrigade([FromBody] DeleteUserFromBrigadeRequest model)
    {
        var response = await _shiftService.DeleteUserFromBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }
}