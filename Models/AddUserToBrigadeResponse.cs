using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AddUserToBrigadeResponse : ResponseBase
{
    public AddUserToBrigadeResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public AddUserToBrigadeResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}