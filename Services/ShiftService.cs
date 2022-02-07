using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DutyAndConductorManager.Api.Services;

public interface IShiftService
{
    Task<Brigade> GetById(int id);
    Task<IEnumerable<Brigade>> GetAll();
    Task<IEnumerable<BrigadeUser>> GetUsersInBrigade(int id);
}

public class ShiftService : IShiftService
{
    private readonly ConductorDb _context;

    public ShiftService(ConductorDb context)
    {
        _context = context;
    }

    public async Task<Brigade> GetById(int id) => await _context.Brigades.Include(x => x.BrigadeUsers).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Brigade>> GetAll() => await _context.Brigades.Include(x => x.BrigadeUsers).ThenInclude(x => x.User).ToListAsync();

    public async Task<IEnumerable<BrigadeUser>> GetUsersInBrigade(int id) => await _context.BrigadeUsers.Include(x => x.User).Where(x => x.BrigadeId == id).ToListAsync();
}