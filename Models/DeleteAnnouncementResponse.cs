using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class DeleteAnnouncementResponse : ResponseBase
{
    public DeleteAnnouncementResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public DeleteAnnouncementResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}