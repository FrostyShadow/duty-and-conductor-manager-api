using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class DeleteUserFromBrigadeResponse : ResponseBase
{
    public DeleteUserFromBrigadeResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public DeleteUserFromBrigadeResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}