using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class SetPasswordResponse : ResponseBase
{
    public SetPasswordResponse(bool isSuccess) : base(isSuccess)
    {
    }

    public SetPasswordResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
    }
}