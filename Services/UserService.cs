using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;
using DutyAndConductorManager.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DutyAndConductorManager.Api.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
}

public class UserService : IUserService
{
    private IList<User> _users = new List<User>
    {
        new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test123" }
    };

    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appsettings)
    {
        _appSettings = appsettings.Value;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        if (user == null) return null;

        var token = GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<IEnumerable<User>> GetAll() => _users;

    public async Task<User> GetById(int id) => _users.FirstOrDefault(x => x.Id == id);

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.ApiSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}