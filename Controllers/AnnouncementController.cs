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
public class AnnouncementController : ControllerBase
{
    private IAnnouncementService _announcementService;

    public AnnouncementController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    [HttpGet]
    [SwaggerOperation("Gets announcement by it's ID")]
    [ProducesResponseType(typeof(Announcement), 200)]
    public async Task<IActionResult> GetById([FromQuery, SwaggerParameter("Announcement ID", Required = true)] int id)
    {
        var response = await _announcementService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of all announcements")]
    [ProducesResponseType(typeof(IList<Announcement>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _announcementService.GetAll();
        return Ok(response);
    }

    [HttpPost]
    [SwaggerOperation("Creates new announcement")]
    [ProducesResponseType(typeof(AddAnnouncementResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> AddAnnouncement([FromBody, SwaggerRequestBody("Announcement data")] AddAnnouncementRequest model)
    {
        var response = await _announcementService.AddAnnouncement(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response);
    }

    [HttpPost]
    [SwaggerOperation("Edits existing announcement")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> EditAnnouncement([FromBody, SwaggerRequestBody("Announcement data")] EditAnnouncementRequest model)
    {
        var response = await _announcementService.EditAnnouncement(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Deletes existing announcement")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteAnnouncement([FromBody, SwaggerRequestBody("Announcement ID")] DeleteAnnouncementRequest model)
    {
        var response = await _announcementService.DeleteAnnouncement(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }
}