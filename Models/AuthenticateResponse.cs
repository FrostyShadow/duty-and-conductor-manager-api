using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AuthenticateResponse : ResponseBase
{
    public int Id {get;set;}
    public string? FirstName {get;set;}
    public string? LastName {get;set;}
    public string? Username {get;set;}
    public string? Email {get;set;}
    public bool? IsActive {get;set;}
    public Role? Role {get;set;}
    public DateTime? BirthDate {get;set;}
    public bool? IsTrained {get;set;}
    public string? PhoneNumber {get;set;}
    public string? Photo {get;set;}
    public string? Token {get;set;}

    public AuthenticateResponse(bool isSuccess, User user, string token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.Username;
        Email = user.Email;
        IsActive = user.IsActive;
        Role = user.Role;
        BirthDate = user.BirthDate;
        IsTrained = user.IsTrained;
        PhoneNumber = user.PhoneNumber;
        Photo = user.Photo;
        Token = token;
        IsSuccess = isSuccess;
    }

    public AuthenticateResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
    }
}