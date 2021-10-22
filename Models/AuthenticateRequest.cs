using System.ComponentModel.DataAnnotations;

namespace DutyAndConductorManager.Api.Models;

public class AuthenticateRequest
{
    [Required]
    public string Username {get;set;}
    [Required]
    public string Password {get;set;}
}