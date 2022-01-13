using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class EditAnnouncementResponse : ResponseBase
{
    public EditAnnouncementResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public EditAnnouncementResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}