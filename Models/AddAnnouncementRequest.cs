namespace DutyAndConductorManager.Api.Models;

public class AddAnnouncementRequest
{
    public int CreatorId {get;set;}
    public string Message {get;set;}
    public int AnnouncementTypeId {get;set;}
}