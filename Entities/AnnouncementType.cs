namespace DutyAndConductorManager.Api.Entities;

public class AnnouncementType
{
    public int Id {get;set;}
    public string Name {get;set;}

    public IList<Announcement> Announcements {get;set;}
}