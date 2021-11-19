using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Helpers;
using DutyAndConductorManager.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SecurityToken = DutyAndConductorManager.Api.Entities.SecurityToken;

namespace DutyAndConductorManager.Api.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetByIdAsync(int id);
    Task<AddUserResponse> AddUser(AddUserRequest model);
}

public class UserService : IUserService
{

    private readonly AppSettings _appSettings;
    private readonly ConductorDb _context;

    public UserService(IOptionsSnapshot<AppSettings> appsettings, ConductorDb context)
    {
        _appSettings = appsettings.Value;
        _context = context;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        var user = await _context.Users.Include(e => e.Role).SingleOrDefaultAsync(x => x.Username == model.Username && x.Password == HashPassword(model.Password));

        if (user == null) return null;

        var token = GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<IEnumerable<User>> GetAll() => await _context.Users.Include(e => e.Role).ToListAsync();

    public async Task<User> GetByIdAsync(int id) => await _context.Users.Include(e => e.Role).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<AddUserResponse> AddUser(AddUserRequest model)
    {
        if(await _context.Users.AnyAsync(x => x.Username == model.Username || x.Email == model.Email))
            return null;

        var user = await _context.Users.AddAsync(new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Username = model.Username,
            Email = model.Email,
            RoleId = model.RoleId,
            BirthDate = model.BirthDate,
            IsTrained = model.IsTrained,
            PhoneNumber = model.PhoneNumber
        });

        await _context.SaveChangesAsync();

        var securityToken = new SecurityToken
        {
            CreatedDateTime = DateTime.Now,
            UserId = user.Entity.Id,
            Token = Guid.NewGuid()
        };

        await _context.SecurityTokens.AddAsync(securityToken);
        await _context.SaveChangesAsync();

        var securityUrl = $"http://localhost:5284/activate/{user.Entity.Id}/{securityToken.Token}";

        Console.WriteLine(securityUrl);

        return new AddUserResponse(user.Entity.Id);
    }

    private User GetById(int id) => _context.Users.FirstOrDefault(x => x.Id == id);

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.ApiSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("role", user.Role.Name) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private string HashPassword(string rawPassword)
    {
        var clearBytes = Encoding.Unicode.GetBytes(rawPassword);
        using var encryptor = Aes.Create();
        var pdb = new Rfc2898DeriveBytes(_appSettings.ApiSecret,
            new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        encryptor.Key = pdb.GetBytes(32);
        encryptor.IV = pdb.GetBytes(16);
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(clearBytes, 0, clearBytes.Length);
        cs.Close();
        return Convert.ToBase64String(ms.ToArray());
    }
}