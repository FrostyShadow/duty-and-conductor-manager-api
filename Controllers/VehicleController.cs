using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;
using DutyAndConductorManager.Api.Models;
using DutyAndConductorManager.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DutyAndConductorManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Produces("application/json")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    [SwaggerOperation("Gets vehicle by it's ID")]
    [ProducesResponseType(typeof(Vehicle), 200)]
    public async Task<IActionResult> GetVehicleById([FromQuery, SwaggerParameter("Vehicle ID")] int id)
    {
        var response = await _vehicleService.GetVehicleById(id);
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of all vehicles")]
    [ProducesResponseType(typeof(IList<Vehicle>), 200)]
    public async Task<IActionResult> GetAllVehicles()
    {
        var response = await _vehicleService.GetAllVehicles();
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets vehicle model by it's ID")]
    [ProducesResponseType(typeof(VehicleModel), 200)]
    public async Task<IActionResult> GetVehicleModelById([FromQuery, SwaggerParameter("Vehicle model ID")] int id)
    {
        var response = await _vehicleService.GetVehicleModelById(id);
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of all vehicle models")]
    [ProducesResponseType(typeof(IList<VehicleModel>), 200)]
    public async Task<IActionResult> GetAllVehicleModels()
    {
        var response = await _vehicleService.GetAllVehicleModels();
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets vehicle manufacturer by it's ID")]
    [ProducesResponseType(typeof(VehicleManufacturer), 200)]
    public async Task<IActionResult> GetVehicleManufacturerById([FromQuery, SwaggerParameter("Vehicle manufacturer ID")] int id)
    {
        var response = await _vehicleService.GetVehicleManufacturerById(id);
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of all vehicle manufacturers")]
    [ProducesResponseType(typeof(IList<VehicleManufacturer>), 200)]
    public async Task<IActionResult> GetAllVehicleManufacturers()
    {
        var response = await _vehicleService.GetAllVehicleManufacturers();
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets vehicle set by it's ID")]
    [ProducesResponseType(typeof(Set), 200)]
    public async Task<IActionResult> GetSetById([FromQuery, SwaggerParameter("Vehicle set ID")] int id)
    {
        var response = await _vehicleService.GetSetById(id);
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of all vehicle sets")]
    [ProducesResponseType(typeof(IList<Set>), 200)]
    public async Task<IActionResult> GetAllSets()
    {
        var response = await _vehicleService.GetAllSets();
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of vehicles by set ID")]
    [ProducesResponseType(typeof(IList<VehicleSet>), 200)]
    public async Task<IActionResult> GetVehiclesInSet([FromQuery, SwaggerParameter("Set ID")] int id)
    {
        var response = await _vehicleService.GetVehiclesInSet(id);
        return Ok(response);
    }

    [HttpPost]
    [SwaggerOperation("Creates new vehicle")]
    [ProducesResponseType(typeof(AddVehicleResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> AddVehicle([FromBody, SwaggerRequestBody("Vehicle data")] AddVehicleRequest model)
    {
        var response = await _vehicleService.AddVehicle(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Creates new vehicle model")]
    [ProducesResponseType(typeof(AddVehicleModelResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> AddVehicleModel([FromBody, SwaggerRequestBody("Vehicle model data")] AddVehicleModelRequest model)
    {
        var response = await _vehicleService.AddVehicleModel(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Creates new vehicle manufacturer")]
    [ProducesResponseType(typeof(AddVehicleManufacturerResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> AddVehicleManufacturer([FromBody, SwaggerRequestBody("Vehicle manufacturer data")] AddVehicleManufacturerRequest model)
    {
        var response = await _vehicleService.AddVehicleManufacturer(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Creates new vehicle set")]
    [ProducesResponseType(typeof(AddSetResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> AddSet([FromBody, SwaggerRequestBody("Vehicle set data")] AddSetRequest model)
    {
        var response = await _vehicleService.AddSet(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Edits existing vehicle")]
    [ProducesResponseType(typeof(EditVehicleResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> EditVehicle([FromBody, SwaggerRequestBody("Vehicle data")] EditVehicleRequest model)
    {
        var response = await _vehicleService.EditVehicle(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Edits existing vehicle model")]
    [ProducesResponseType(typeof(EditVehicleModelResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> EditVehicleModel([FromBody, SwaggerRequestBody("Vehicle model data")] EditVehicleModelRequest model)
    {
        var response = await _vehicleService.EditVehicleModel(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Edits existing vehicle manufacturer")]
    [ProducesResponseType(typeof(EditVehicleManufacturerResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> EditVehicleManufacturer([FromBody, SwaggerRequestBody("Vehicle manufacturer data")] EditVehicleManufacturerRequest model)
    {
        var response = await _vehicleService.EditVehicleManufacturer(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Edits existing vehicle set")]
    [ProducesResponseType(typeof(EditSetResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> EditSet([FromBody, SwaggerRequestBody("Vehicle set data")] EditSetRequest model)
    {
        var response = await _vehicleService.EditSet(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Deletes existing vehicle")]
    [ProducesResponseType(typeof(DeleteVehicleResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteVehicle([FromBody, SwaggerRequestBody("Vehicle ID")] DeleteVehicleRequest model)
    {
        var response = await _vehicleService.DeleteVehicle(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Deletes existing vehicle model")]
    [ProducesResponseType(typeof(DeleteVehicleModelResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteVehicleModel([FromBody, SwaggerRequestBody("Vehicle model ID")] DeleteVehicleModelRequest model)
    {
        var response = await _vehicleService.DeleteVehicleModel(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Deletes existing vehicle manufacturer")]
    [ProducesResponseType(typeof(DeleteVehicleManufacturerResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteVehicleManufacturer([FromBody, SwaggerRequestBody("Vehicle manufacturer ID")] DeleteVehicleManufacturerRequest model)
    {
        var response = await _vehicleService.DeleteVehicleManufacturer(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Delete existing vehicle set")]
    [ProducesResponseType(typeof(DeleteSetResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteSet([FromBody, SwaggerRequestBody("Vehicle set ID")] DeleteSetRequest model)
    {
        var response = await _vehicleService.DeleteSet(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });
        return Ok(response.IsSuccess);
    }
}