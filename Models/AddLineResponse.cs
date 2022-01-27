using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AddLineResponse : ResponseBase
{
    public AddLineResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public AddLineResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}