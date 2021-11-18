using DutyAndConductorManager.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DutyAndConductorManager.Api.Contexts;

public class ConductorDb : DbContext
{
    public ConductorDb(DbContextOptions<ConductorDb> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne<Role>(e => e.Role)
            .WithMany(e => e.Users)
            .HasForeignKey(e => e.RoleId);

        modelBuilder.Entity<SecurityToken>()
            .HasOne<User>(e => e.User)
            .WithMany(e => e.SecurityTokens)
            .HasForeignKey(e => e.UserId);

        // Static data
        modelBuilder.Entity<Role>()
            .HasData(new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "ShiftManager"
                },
                new Role
                {
                    Id = 3,
                    Name = "Conductor"
                }
            });
    }

    public DbSet<User> Users {get;set;}
    public DbSet<Role> Roles {get;set;}
    public DbSet<SecurityToken> SecurityTokens {get;set;}
}