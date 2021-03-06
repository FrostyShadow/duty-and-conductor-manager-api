namespace DutyAndConductorManager.Api.Entities;

public class SecurityToken
{
    public int Id {get;set;}
    public int UserId {get;set;}
    public DateTime CreatedDateTime {get;set;}
    public Guid Token {get;set;}
    public int SecurityTokenTypeId {get;set;}
    public bool IsUsed {get;set;}

    public User User {get;set;}
    public SecurityTokenType SecurityTokenType {get;set;}

}