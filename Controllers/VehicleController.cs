using DutyAndConductorManager.Api.Models;
using DutyAndConductorManager.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DutyAndConductorManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVehicleById([FromQuery] int id)
    {
        var response = await _vehicleService.GetVehicleById(id);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles()
    {
        var response = await _vehicleService.GetAllVehicles();
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetVehicleModelById([FromQuery] int id)
    {
        var response = await _vehicleService.GetVehicleModelById(id);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicleModels()
    {
        var response = await _vehicleService.GetAllVehicleModels();
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetVehicleManufacturerById([FromQuery] int id)
    {
        var response = await _vehicleService.GetVehicleManufacturerById(id);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicleManufacturers()
    {
        var response = await _vehicleService.GetAllVehicleManufacturers();
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetSetById([FromQuery] int id)
    {
        var response = await _vehicleService.GetSetById(id);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSets()
    {
        var response = await _vehicleService.GetAllSets();
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetVehiclesInSet([FromQuery] int id)
    {
        var response = await _vehicleService.GetVehiclesInSet(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddVehicle([FromBody] AddVehicleRequest model)
    {
        var response = await _vehicleService.AddVehicle(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddVehicleModel([FromBody] AddVehicleModelRequest model)
    {
        var response = await _vehicleService.AddVehicleModel(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddVehicleManufacturer([FromBody] AddVehicleManufacturerRequest model)
    {
        var response = await _vehicleService.AddVehicleManufacturer(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddSet([FromBody] AddSetRequest model)
    {
        var response = await _vehicleService.AddSet(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> EditVehicle([FromBody] EditVehicleRequest model)
    {
        var response = await _vehicleService.EditVehicle(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> EditVehicleModel([FromBody] EditVehicleModelRequest model)
    {
        var response = await _vehicleService.EditVehicleModel(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> EditVehicleManufacturer([FromBody] EditVehicleManufacturerRequest model)
    {
        var response = await _vehicleService.EditVehicleManufacturer(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> EditSet([FromBody] EditSetRequest model)
    {
        var response = await _vehicleService.EditSet(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteVehicle([FromBody] DeleteVehicleRequest model)
    {
        var response = await _vehicleService.DeleteVehicle(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteVehicleModel([FromBody] DeleteVehicleModelRequest model)
    {
        var response = await _vehicleService.DeleteVehicleModel(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteVehicleManufacturer([FromBody] DeleteVehicleManufacturerRequest model)
    {
        var response = await _vehicleService.DeleteVehicleManufacturer(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteSet([FromBody] DeleteSetRequest model)
    {
        var response = await _vehicleService.DeleteSet(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response);
    }
}