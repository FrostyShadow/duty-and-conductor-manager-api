using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Entities;

namespace DutyAndConductorManager.Api.Services;

public interface IAnnouncementService
{
    Task<Announcement> GetById(int id);
    Task<IEnumerable<Announcement>> GetAll();
    Task AddAnnouncement();
    Task EditAnnouncement();
    Task DeleteAnnouncement();
}

public class AnnouncementService : IAnnouncementService
{
    private ConductorDb _context;

    public AnnouncementService(ConductorDb context)
    {
        _context = context;
    }
}