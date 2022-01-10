namespace DutyAndConductorManager.Api.Models;

public class EditAnnouncementRequest
{
    public int Id {get;set;}
    public int EditorId {get;set;}
    public string Message {get;set;}
    public int? AnnouncementTypeId {get;set;}
}