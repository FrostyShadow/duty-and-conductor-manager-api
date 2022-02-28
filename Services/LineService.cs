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
    Task<EditLineResponse> EditLine(EditLineRequest model);
    Task<DeleteLineResponse> DeleteLine(DeleteLineRequest model);
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

    public async Task<DeleteLineResponse> DeleteLine(DeleteLineRequest model)
    {
        var line = await _context.Lines.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (line == null)
            return new DeleteLineResponse(false, "Line not found");

        _context.Lines.Remove(line);
        await _context.SaveChangesAsync();

        return new DeleteLineResponse(true);
    }

    public async Task<EditLineResponse> EditLine(EditLineRequest model)
    {
        var line = await _context.Lines.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (line == null)
            return new EditLineResponse(false, "Line not found");

        if (!await _context.LineTypes.AnyAsync(x => x.Id == model.LineTypeId))
            return new EditLineResponse(false, "Line type not found");

        line.LineTypeId = model.LineTypeId;
        line.Number = model.Number;
        line.StartDateTime = model.StartDateTime;
        line.EndDateTime = model.EndDateTime;

        await _context.SaveChangesAsync();

        return new EditLineResponse(true);
    }

    public async Task<IEnumerable<Line>> GetAll() => await _context.Lines.Include(x => x.LineType).ToListAsync();

    public async Task<Line> GetById(int id) => await _context.Lines.Include(x => x.LineType).FirstOrDefaultAsync(x => x.Id == id);
}