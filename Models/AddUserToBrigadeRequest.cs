namespace DutyAndConductorManager.Api.Models;

public class AddUserToBrigadeRequest
{
    public int BrigadeId {get;set;}
    public int UserId {get;set;}
    public bool IsManager {get;set;}
}