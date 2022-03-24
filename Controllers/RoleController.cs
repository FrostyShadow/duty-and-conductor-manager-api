using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DutyAndConductorManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Produces("application/json")]
public class RoleController : ControllerBase
{
    private IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    [SwaggerOperation("Gets role by it's ID")]
    [ProducesResponseType(typeof(Role), 200)]
    public async Task<IActionResult> GetById([FromQuery, SwaggerParameter("Role ID")] int id)
    {
        var result = await _roleService.GetById(id);
        return Ok(result);
    }

    [HttpGet]
    [SwaggerOperation("Gets list of all roles")]
    [ProducesResponseType(typeof(IList<Role>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _roleService.GetAll();
        return Ok(result);
    }
}