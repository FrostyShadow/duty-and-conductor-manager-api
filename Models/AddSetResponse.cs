using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AddSetResponse : ResponseBase
{
    public AddSetResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public AddSetResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}