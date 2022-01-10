using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DutyAndConductorManager.Api.Services;

public interface IAnnouncementService
{
    Task<Announcement> GetByIdAsync(int id);
    Announcement GetById(int id);
    Task<IEnumerable<Announcement>> GetAll();
    Task<AddAnnouncementResponse> AddAnnouncement(AddAnnouncementRequest model);
    Task<EditAnnouncementResponse> EditAnnouncement(EditAnnouncementRequest model);
    Task<DeleteAnnouncementResponse> DeleteAnnouncement(DeleteAnnouncementRequest model);
}

public class AnnouncementService : IAnnouncementService
{
    private ConductorDb _context;

    public AnnouncementService(ConductorDb context)
    {
        _context = context;
    }

    public async Task<Announcement> GetByIdAsync(int id) => await _context.Announcements.FirstOrDefaultAsync(x => x.Id == id);

    public Announcement GetById(int id) => _context.Announcements.FirstOrDefault(x => x.Id == id);

    public async Task<IEnumerable<Announcement>> GetAll() => await _context.Announcements.ToListAsync();

    public async Task<AddAnnouncementResponse> AddAnnouncement(AddAnnouncementRequest model)
    {
        if (!await _context.Users.AnyAsync(x => x.Id == model.CreatorId && x.RoleId == 1))
            return new AddAnnouncementResponse(false, "Invalid creator ID or user doesn't have permissions to perform this action");

        if (!await _context.AnnouncementTypes.AnyAsync(x => x.Id == model.AnnouncementTypeId))
            return new AddAnnouncementResponse(false, "Invalid annoucement type");

        var announcement = await _context.Announcements.AddAsync(new Announcement
        {
            CreatorId = model.CreatorId,
            CreatedDateTime = DateTime.UtcNow,
            Message = model.Message,
            AnnouncementTypeId = model.AnnouncementTypeId
        });
        await _context.SaveChangesAsync();

        return new AddAnnouncementResponse(announcement.Entity.Id, true);
    }

    public async Task<EditAnnouncementResponse> EditAnnouncement(EditAnnouncementRequest model)
    {
        if (!await _context.Users.AnyAsync(x => x.Id == model.EditorId && x.RoleId == 1))
            return new EditAnnouncementResponse(false, "Invalid editor ID or user doesn't have permissions to perform this action");

        if (!await _context.AnnouncementTypes.AnyAsync(x => x.Id == model.AnnouncementTypeId))
            return new EditAnnouncementResponse(false, "Invalid annoucement type");

        var announcement = GetById(model.Id);

        if (announcement == null)
            return new EditAnnouncementResponse(false, "Invalid announcement ID");

        announcement.AnnouncementTypeId = model.AnnouncementTypeId ?? announcement.AnnouncementTypeId;
        announcement.Message = model.Message;
        await _context.SaveChangesAsync();

        return new EditAnnouncementResponse(true);
    }

    public async Task<DeleteAnnouncementResponse> DeleteAnnouncement(DeleteAnnouncementRequest model)
    {
        if (!await _context.Users.AnyAsync(x => x.Id == model.DeleterId && x.RoleId == 1))
            return new DeleteAnnouncementResponse(false, "Invalid editor ID or user doesn't have permissions to perform this action");

        var announcement = GetById(model.Id);

        if (announcement == null)
            return new DeleteAnnouncementResponse(false, "Invalid announcement ID");

        _context.Announcements.Remove(announcement);
        await _context.SaveChangesAsync();

        return new DeleteAnnouncementResponse(true);
    }
}