using DutyAndConductorManager.Api.Entities;

namespace DutyAndConductorManager.Api.Models;

public class ActivateResponse
{
    public bool IsSuccess {get;set;}
    public Guid SetPasswordToken {get;set;}
    public string? ErrorMessage {get;set;}

    public ActivateResponse(bool isSuccess, Guid setPasswordToken)
    {
        IsSuccess = isSuccess;
        SetPasswordToken = setPasswordToken;
    }

    public ActivateResponse(bool isSuccess, string errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}