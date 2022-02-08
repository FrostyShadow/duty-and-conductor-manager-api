using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DutyAndConductorManager.Api.Services;

public interface IShiftService
{
    Task<Brigade> GetById(int id);
    Task<IEnumerable<Brigade>> GetAll();
    Task<IEnumerable<BrigadeUser>> GetUsersInBrigade(int id);

    Task<AddBrigadeResponse> AddBrigade(AddBrigadeRequest model);
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

    public async Task<AddBrigadeResponse> AddBrigade(AddBrigadeRequest model)
    {
        if (!await _context.Lines.AnyAsync(x => x.Id == model.LineId))
            return new AddBrigadeResponse(false, "Line not found");

        if (!await _context.Sets.AnyAsync(x => x.Id == model.SetId))
            return new AddBrigadeResponse(false, "Vehicle set not found");

        if (await _context.Brigades.AnyAsync(x => x.Name == model.Name && x.LineId == model.LineId && x.DateTimeFrom >= model.DateTimeFrom && x.DateTimeTo <= model.DateTimeTo))
            return new AddBrigadeResponse(false, "Brigade already exists");

        await _context.Brigades.AddAsync(new Brigade
        {
            Name = model.Name,
            SetId = model.SetId,
            LineId = model.LineId,
            DateTimeFrom = model.DateTimeFrom,
            DateTimeTo = model.DateTimeTo,
            ConductorLimit = model.ConductorLimit
        });
        await _context.SaveChangesAsync();

        return new AddBrigadeResponse(true);
    }

}