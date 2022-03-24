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
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [SwaggerOperation("Authenticates user")]
    [ProducesResponseType(typeof(AuthenticateResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> Authenticate([FromBody, SwaggerRequestBody("Authenticate request data")] AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model);

        if(!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response);
    }

    [HttpPost]
    [SwaggerOperation("Activates user account")]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> Activate([FromBody, SwaggerRequestBody("Activation request data")] ActivateRequest model)
    {
        var response = await _userService.Activate(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.SetPasswordToken);
    }

    [HttpPost]
    [SwaggerOperation("Generates password reset token")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> ForgotPassword([FromBody, SwaggerRequestBody("User email address")] ForgotPasswordRequest model)
    {
        var response = await _userService.ForgotPassword(model);

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Resets password")]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> PasswordReset([FromBody, SwaggerRequestBody("Password reset request data")] PasswordResetRequest model)
    {
        var response = await _userService.PasswordReset(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.SetPasswordToken);
    }

    [HttpPost]
    [SwaggerOperation("Sets password for user")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> SetPassword([FromBody, SwaggerRequestBody("Set password request data")] SetPasswordRequest model)
    {
        var response = await _userService.SetPassword(model);

        if (!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(true);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of all users")]
    [ProducesResponseType(typeof(IList<User>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpGet]
    [SwaggerOperation("Gets user by it's ID")]
    [ProducesResponseType(typeof(User), 200)]
    public async Task<IActionResult> GetById([FromQuery, SwaggerParameter("User ID")] int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    [SwaggerOperation("Creates new user")]
    [ProducesResponseType(typeof(AddUserResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> AddUser([FromBody, SwaggerRequestBody("User data")] AddUserRequest model)
    {
        var response = await _userService.AddUser(model);

        if(!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response);
    }

    [HttpPost]
    [SwaggerOperation("Edits existing user")]
    [ProducesResponseType(typeof(EditUserResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> EditUser([FromBody, SwaggerRequestBody("User data")] EditUserRequest model)
    {
        var response = await _userService.EditUser(model);

        if(!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }

    [HttpPost]
    [SwaggerOperation("Deletes existing user")]
    [ProducesResponseType(typeof(DeleteUserResponse), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteUser([FromBody, SwaggerRequestBody("User ID")] DeleteUserRequest model)
    {
        var response = await _userService.DeleteUser(model);

        if(!response.IsSuccess)
            return BadRequest(new { message = response.ErrorMessage });

        return Ok(response.IsSuccess);
    }
}