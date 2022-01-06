namespace DutyAndConductorManager.Api.Models;

public class EditUserRequest
{
    public int Id {get;set;}
    public string? FirstName {get;set;}
    public string? LastName {get;set;}
    public string? Password {get;set;}
    public string? Email {get;set;}
    public bool IsActive {get;set;}
    public int? RoleId {get;set;}
    public bool IsTrained {get;set;}
    public string? PhoneNumber {get;set;}
    public string? Photo {get;set;}
    public bool IsAdminEdit {get;set;}
    public int EditingUserId {get;set;}
}