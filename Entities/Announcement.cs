
using System.Text.Json.Serialization;

namespace DutyAndConductorManager.Api.Entities;

public class Announcement
{
    public int Id {get;set;}
    public int CreatorId {get;set;}
    public DateTime CreatedDateTime {get;set;}
    public string Message {get;set;}
    public int AnnouncementTypeId {get;set;}

    public User User {get;set;}
    public AnnouncementType AnnouncementType {get;set;}
}