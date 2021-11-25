namespace DutyAndConductorManager.Api.Helpers;

public abstract class ResponseBase
{
    public bool IsSuccess {get;set;}
    public string? ErrorMessage {get;set;}

    public ResponseBase()
    {
        
    }

    public ResponseBase(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public ResponseBase(bool isSuccess, string errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}