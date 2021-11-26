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
    Task<ActivateResponse> Activate(ActivateRequest model);
    Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest model);
    Task<PasswordResetResponse> PasswordReset(PasswordResetRequest model);
    Task<SetPasswordResponse> SetPassword(SetPasswordRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetByIdAsync(int id);
    Task<AddUserResponse> AddUser(AddUserRequest model);
    Task<DeleteUserResponse> DeleteUser(DeleteUserRequest model);
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
        var user = await _context.Users.Include(e => e.Role).SingleOrDefaultAsync(x => x.Username == model.Username && x.Password == HashPassword(model.Password) && x.IsActive);

        if (user == null) return new AuthenticateResponse(false, "Username or password is incorrect");

        var token = GenerateJwtToken(user);

        return new AuthenticateResponse(true, user, token);
    }

    public async Task<ActivateResponse> Activate(ActivateRequest model)
    {
        var activationToken = await _context.SecurityTokens.FirstOrDefaultAsync(x => x.UserId == model.Id && x.Token == model.Token && x.SecurityTokenTypeId == 1 && !x.IsUsed);

        if (activationToken == null) 
            return new ActivateResponse(false, "Activation token is incorrect");

        if (activationToken.CreatedDateTime.AddHours(24) < DateTime.UtcNow)
            return new ActivateResponse(false, "Activation token is expired");

        var user = GetById(model.Id);

        if (user.IsActive)
            return new ActivateResponse(false, "Account is already active");

        user.IsActive = true;

        var setPasswordToken = new SecurityToken
        {
            CreatedDateTime = DateTime.UtcNow,
            Token = Guid.NewGuid(),
            SecurityTokenTypeId = 2,
            UserId = user.Id,
            IsUsed = false
        };

        await _context.SecurityTokens.AddAsync(setPasswordToken);

        await _context.SaveChangesAsync();

        return new ActivateResponse(true, setPasswordToken.Token);
    }

    // TODO: Add mail server support to send activation links via email
    public async Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

        if (user == null)
            return new ForgotPasswordResponse(true);

        var forgotPasswordToken = new SecurityToken
        {
            CreatedDateTime = DateTime.UtcNow,
            Token = Guid.NewGuid(),
            SecurityTokenTypeId = 3,
            UserId = user.Id,
            IsUsed = false
        };

        await _context.SecurityTokens.AddAsync(forgotPasswordToken);

        await _context.SaveChangesAsync();

        var securityUrl = $"http://localhost:5284/forgot-password/{user.Id}/{forgotPasswordToken.Token}";

        // TODO: Replace this line with mail sending
        Console.WriteLine(securityUrl);

        return new ForgotPasswordResponse(true);
    }

    public async Task<PasswordResetResponse> PasswordReset(PasswordResetRequest model)
    {
        var passwordResetToken = await _context.SecurityTokens.FirstOrDefaultAsync(x => x.UserId == model.Id && x.Token == model.Token && x.SecurityTokenTypeId == 3 && !x.IsUsed);

        if (passwordResetToken == null) 
            return new PasswordResetResponse(false, "Password reset token is incorrect");

        if (passwordResetToken.CreatedDateTime.AddHours(24) < DateTime.UtcNow)
            return new PasswordResetResponse(false, "Password reset token is expired");

        var setPasswordToken = new SecurityToken
        {
            CreatedDateTime = DateTime.UtcNow,
            Token = Guid.NewGuid(),
            SecurityTokenTypeId = 2,
            UserId = model.Id,
            IsUsed = false
        };

        await _context.SecurityTokens.AddAsync(setPasswordToken);

        await _context.SaveChangesAsync();

        return new PasswordResetResponse(true, setPasswordToken.Token);
    }

    public async Task<SetPasswordResponse> SetPassword(SetPasswordRequest model)
    {
        var setPasswordToken = await _context.SecurityTokens.FirstOrDefaultAsync(x => x.UserId == model.Id && x.Token == model.Token && x.SecurityTokenTypeId == 2 && !x.IsUsed);

        if (setPasswordToken == null) 
            return new SetPasswordResponse(false, "Set password token is incorrect");

        if (setPasswordToken.CreatedDateTime.AddHours(24) < DateTime.UtcNow)
            return new SetPasswordResponse(false, "Set password token is expired");

        var user = GetById(model.Id);

        user.Password = HashPassword(model.Password);

        await _context.SaveChangesAsync();

        return new SetPasswordResponse(true);
    }

    public async Task<IEnumerable<User>> GetAll() => await _context.Users.Include(e => e.Role).ToListAsync();

    public async Task<User> GetByIdAsync(int id) => await _context.Users.Include(e => e.Role).FirstOrDefaultAsync(x => x.Id == id);

    // TODO: Add mail server support to send activation links via email
    public async Task<AddUserResponse> AddUser(AddUserRequest model)
    {
        if(await _context.Users.AnyAsync(x => x.Username == model.Username || x.Email == model.Email))
            return new AddUserResponse(false, "Username or Email already in use");

        var user = await _context.Users.AddAsync(new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Username = model.Username,
            Password = "empty",
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
            Token = Guid.NewGuid(),
            SecurityTokenTypeId = 1,
            IsUsed = false
        };

        await _context.SecurityTokens.AddAsync(securityToken);
        await _context.SaveChangesAsync();

        var securityUrl = $"http://localhost:5284/activate/{user.Entity.Id}/{securityToken.Token}";

        // TODO: Replace this line with mail sending
        Console.WriteLine(securityUrl);

        return new AddUserResponse(user.Entity.Id, true);
    }

    private User GetById(int id) => _context.Users.FirstOrDefault(x => x.Id == id);

    public async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest model)
    {
        var user = GetById(model.Id);

        if (user == null)
            return new DeleteUserResponse(false, "User not found");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return new DeleteUserResponse(true);
    }

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