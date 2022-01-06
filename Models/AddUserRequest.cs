namespace DutyAndConductorManager.Api.Models;

public class AddUserRequest
{
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Username {get;set;}
    public string Email {get;set;}
    public int RoleId {get;set;}
    public DateTime BirthDate {get;set;}
    public bool IsTrained {get;set;}
    public string? PhoneNumber {get;set;}
}