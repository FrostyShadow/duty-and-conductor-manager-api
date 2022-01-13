using DutyAndConductorManager.Api.Models;
using DutyAndConductorManager.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DutyAndConductorManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AnnouncementController : ControllerBase
{
    private IAnnouncementService _announcementService;

    public AnnouncementController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var response = await _announcementService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _announcementService.GetAll();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddAnnouncement([FromBody] AddAnnouncementRequest model)
    {
        var response = await _announcementService.AddAnnouncement(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> EditAnnouncement([FromBody] EditAnnouncementRequest model)
    {
        var response = await _announcementService.EditAnnouncement(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAnnouncement([FromBody] DeleteAnnouncementRequest model)
    {
        var response = await _announcementService.DeleteAnnouncement(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }
}