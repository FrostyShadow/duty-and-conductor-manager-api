using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class ActivateResponse : ResponseBase
{
    public Guid SetPasswordToken {get;set;}

    public ActivateResponse(bool isSuccess, Guid setPasswordToken)
    {
        IsSuccess = isSuccess;
        SetPasswordToken = setPasswordToken;
    }

    public ActivateResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}