using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AddAnnouncementResponse : ResponseBase
{
    public int Id {get;set;}

    public AddAnnouncementResponse(int id, bool isSuccess) : base(isSuccess)
    {
        Id = id;
    }

    public AddAnnouncementResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}