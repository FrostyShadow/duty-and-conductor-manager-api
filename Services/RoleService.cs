using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DutyAndConductorManager.Api.Services;

public interface IRoleService
{
    Task<Role> GetById(int id);
    Task<IEnumerable<Role>> GetAll();
}

public class RoleService : IRoleService
{
    private ConductorDb _context;
    
    public RoleService(ConductorDb context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Role>> GetAll() => await _context.Roles.ToListAsync();

    public async Task<Role> GetById(int id) => await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
}