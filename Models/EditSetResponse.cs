using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class EditSetResponse : ResponseBase
{
    public EditSetResponse(bool isSuccess) : base(isSuccess) {}
    public EditSetResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}