using System.Text.Json.Serialization;

namespace DutyAndConductorManager.Api.Entities;

public class User
{
    public int Id {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Username {get;set;}
    [JsonIgnore]
    public string? Password {get;set;}
    public string Email {get;set;}
    public bool IsActive {get;set;}
    public int RoleId {get;set;}
    public DateTime? BirthDate {get;set;}
    public bool IsTrained {get;set;}
    public string? PhoneNumber {get;set;}
    public string? Photo {get;set;}

    public Role Role {get;set;}

    public IList<SecurityToken> SecurityTokens {get;set;}
}