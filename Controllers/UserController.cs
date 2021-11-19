using DutyAndConductorManager.Api.Models;
using DutyAndConductorManager.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DutyAndConductorManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model);

        if(response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(AddUserRequest model)
    {
        var response = await _userService.AddUser(model);

        if(response == null)
            return BadRequest(new { message = "Username already in use" });

        return Ok(response);
    }
}