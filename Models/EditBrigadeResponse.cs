using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class EditBrigadeResponse : ResponseBase
{
    public EditBrigadeResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public EditBrigadeResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}