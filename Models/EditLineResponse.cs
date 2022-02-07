using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class EditLineResponse : ResponseBase
{
    public EditLineResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public EditLineResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}