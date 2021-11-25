using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class PasswordResetResponse : ResponseBase
{
    public Guid SetPasswordToken {get;set;}

    public PasswordResetResponse(bool isSuccess, Guid setPasswordToken)
    {
        IsSuccess = isSuccess;
        SetPasswordToken = setPasswordToken;
    }

    public PasswordResetResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {}
}