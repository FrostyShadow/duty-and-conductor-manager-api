namespace DutyAndConductorManager.Api.Models;

public class SetPasswordResponse
{
    public bool IsSuccess {get;set;}
    public string? ErrorMessage {get;set;}

    public SetPasswordResponse(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public SetPasswordResponse(bool isSuccess, string errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}