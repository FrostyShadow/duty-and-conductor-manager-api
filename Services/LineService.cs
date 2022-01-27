using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DutyAndConductorManager.Api.Services;

public interface ILineService
{
    Task<Line> GetById(int id);
    Task<IEnumerable<Line>> GetAll();

    Task<AddLineResponse> AddLine(AddLineRequest model);
    Task EditLine();
    Task DeleteLine();
}

public class LineService : ILineService
{
    private readonly ConductorDb _context;

    public LineService(ConductorDb context)
    {
        _context = context;
    }

    public async Task<AddLineResponse> AddLine(AddLineRequest model)
    {
        if (await _context.Lines.AnyAsync(x => x.Number == model.Number && x.LineTypeId == model.LineTypeId && x.EndDateTime >= model.StartDateTime))
            return new AddLineResponse(false, "Line is already active");

        if (!await _context.LineTypes.AnyAsync(x => x.Id == model.LineTypeId))
            return new AddLineResponse(false, "Line type doesn't exist");

        await _context.Lines.AddAsync(new Line
        {
            Number = model.Number,
            LineTypeId = model.LineTypeId,
            StartDateTime = model.StartDateTime,
            EndDateTime = model.EndDateTime
        });
        await _context.SaveChangesAsync();

        return new AddLineResponse(true);
    }

    public Task DeleteLine()
    {
        throw new NotImplementedException();
    }

    public Task EditLine()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Line>> GetAll() => await _context.Lines.ToListAsync();

    public async Task<Line> GetById(int id) => await _context.Lines.FirstOrDefaultAsync(x => x.Id == id);
}