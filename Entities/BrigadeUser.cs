namespace DutyAndConductorManager.Api.Entities;

public class BrigadeUser
{
    public int BrigadeId {get;set;}
    public int UserId {get;set;}
    public bool IsManager {get;set;}

    public Brigade Brigade {get;set;}
    public User User {get;set;}
}