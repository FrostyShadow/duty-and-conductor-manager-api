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
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model);

        if(!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Activate([FromBody] ActivateRequest model)
    {
        var response = await _userService.Activate(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.SetPasswordToken);
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
    {
        var response = await _userService.ForgotPassword(model);

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> PasswordReset([FromBody] PasswordResetRequest model)
    {
        var response = await _userService.PasswordReset(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.SetPasswordToken);
    }

    [HttpPost]
    public async Task<IActionResult> SetPassword([FromBody] SetPasswordRequest model)
    {
        var response = await _userService.SetPassword(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(true);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequest model)
    {
        var response = await _userService.AddUser(model);

        if(!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> EditUser([FromBody] EditUserRequest model)
    {
        var response = await _userService.EditUser(model);

        if(!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest model)
    {
        var response = await _userService.DeleteUser(model);

        if(!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }
}