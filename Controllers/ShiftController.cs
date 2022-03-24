using DutyAndConductorManager.Api.Services;
using DutyAndConductorManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Produces("application/json")]
public class ShiftController : ControllerBase
{
    private readonly IShiftService _shiftService;

    public ShiftController(IShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    [HttpGet]
    [SwaggerOperation("Gets shift by it's ID")]
    [ProducesResponseType(typeof(Brigade), 200)]
    public async Task<IActionResult> GetById([FromQuery, SwaggerParameter("Shift ID")] int id)
    {
        var response = await _shiftService.GetById(id);

        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of all shifts")]
    [ProducesResponseType(typeof(IList<Brigade>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _shiftService.GetAll();

        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of conductors by shift ID")]
    [ProducesResponseType(typeof(IList<BrigadeUser>), 200)]
    public async Task<IActionResult> GetUsersInBrigade([FromQuery, SwaggerParameter("Shift ID")] int id)
    {
        var response = await _shiftService.GetUsersInBrigade(id);

        return Ok(response);
    }

    [HttpPost]
    [SwaggerOperation("Creates new shift")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> AddBrigade([FromBody, SwaggerRequestBody("Shift data")] AddBrigadeRequest model)
    {
        var response = await _shiftService.AddBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Edits existing shift")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> EditBrigade([FromBody, SwaggerRequestBody("Shift data")] EditBrigadeRequest model)
    {
        var response = await _shiftService.EditBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Deletes existing shift")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteBrigade([FromBody, SwaggerRequestBody("Shift ID")] DeleteBrigadeRequest model)
    {
        var response = await _shiftService.DeleteBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Adds conductor to a shift")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> AddUserToBrigade([FromBody, SwaggerRequestBody("Shift and Conductor ID's")] AddUserToBrigadeRequest model)
    {
        var response = await _shiftService.AddUserToBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Deletes conductor from a shift")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteUserFromBrigade([FromBody, SwaggerRequestBody("Shift and Conductor ID's")] DeleteUserFromBrigadeRequest model)
    {
        var response = await _shiftService.DeleteUserFromBrigade(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }
}