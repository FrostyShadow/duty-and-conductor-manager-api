using DutyAndConductorManager.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DutyAndConductorManager.Api.Contexts;

public class ConductorDb : DbContext
{
    public ConductorDb(DbContextOptions<ConductorDb> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Table definitions
        modelBuilder.Entity<User>()
            .ToTable("Users", x => x.IsTemporal());

        modelBuilder.Entity<Announcement>()
            .ToTable("Announcements", x => x.IsTemporal());

        // Relationships
        modelBuilder.Entity<User>()
            .HasOne<Role>(e => e.Role)
            .WithMany(e => e.Users)
            .HasForeignKey(e => e.RoleId);

        modelBuilder.Entity<SecurityToken>()
            .HasOne<User>(e => e.User)
            .WithMany(e => e.SecurityTokens)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<SecurityToken>()
            .HasOne<SecurityTokenType>(e => e.SecurityTokenType)
            .WithMany(e => e.SecurityTokens)
            .HasForeignKey(e => e.SecurityTokenTypeId);

        modelBuilder.Entity<Announcement>()
            .HasOne<User>(e => e.User)
            .WithMany(e => e.Announcements)
            .HasForeignKey(e => e.CreatorId);

        modelBuilder.Entity<Announcement>()
            .HasOne<AnnouncementType>(e => e.AnnouncementType)
            .WithMany(e => e.Announcements)
            .HasForeignKey(e => e.AnnouncementTypeId);

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

        modelBuilder.Entity<SecurityTokenType>()
            .HasData(new List<SecurityTokenType>
            {
                new SecurityTokenType
                {
                    Id = 1,
                    Name = "ActivationToken"
                },
                new SecurityTokenType
                {
                    Id = 2,
                    Name = "PasswordChangeToken"
                },
                new SecurityTokenType
                {
                    Id = 3,
                    Name = "ForgotPasswordToken"
                }
            });

        modelBuilder.Entity<AnnouncementType>()
            .HasData(new List<AnnouncementType>
            {
                new AnnouncementType
                {
                    Id = 1,
                    Name = "InfoAnnouncement"
                },
                new AnnouncementType
                {
                    Id = 2,
                    Name = "ImportantAnnouncement"
                }
            });
    }

    public DbSet<User> Users {get;set;}
    public DbSet<Role> Roles {get;set;}
    public DbSet<SecurityToken> SecurityTokens {get;set;}
    public DbSet<SecurityTokenType> SecurityTokenTypes {get;set;}
    public DbSet<Announcement> Announcements {get;set;}
    public DbSet<AnnouncementType> AnnouncementTypes {get;set;}
}