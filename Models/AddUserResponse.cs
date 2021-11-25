using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AddUserResponse : ResponseBase
{
    public int Id {get;set;}

    public AddUserResponse(int id, bool isSuccess)
    {
        Id = id;
        IsSuccess = isSuccess;
    }

    public AddUserResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}