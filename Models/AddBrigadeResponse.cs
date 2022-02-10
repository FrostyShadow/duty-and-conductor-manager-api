using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AddBrigadeResponse : ResponseBase
{
    public AddBrigadeResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public AddBrigadeResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}