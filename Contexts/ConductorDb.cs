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


        modelBuilder.Entity<VehicleModel>()
            .HasOne<VehicleManufacturer>(e => e.Manufacturer)
            .WithMany(e => e.Models)
            .HasForeignKey(e => e.ManufacturerId);

        modelBuilder.Entity<VehicleModel>()
            .HasOne<VehicleType>(e => e.VehicleType)
            .WithMany(e => e.Models)
            .HasForeignKey(e => e.VehicleTypeId);

        modelBuilder.Entity<Vehicle>()
            .HasOne<VehicleModel>(e => e.Model)
            .WithMany(e => e.Vehicles)
            .HasForeignKey(e => e.ModelId);

        modelBuilder.Entity<VehicleSet>()
            .HasOne<Vehicle>(e => e.Vehicle)
            .WithMany(e => e.VehicleSets)
            .HasForeignKey(e => e.VehicleId);

        modelBuilder.Entity<VehicleSet>()
            .HasOne<Set>(e => e.Set)
            .WithMany(e => e.VehicleSets)
            .HasForeignKey(e => e.SetId);

        modelBuilder.Entity<VehicleSet>()
            .HasKey(e => new { e.SetId, e.VehicleId });

        modelBuilder.Entity<Line>()
            .HasOne<LineType>(e => e.LineType)
            .WithMany(e => e.Lines)
            .HasForeignKey(e => e.LineTypeId);

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

        modelBuilder.Entity<VehicleType>()
            .HasData(new List<VehicleType>
            {
                new VehicleType
                {
                    Id = 1,
                    Name = "TramEngineCar"
                },
                new VehicleType
                {
                    Id = 2,
                    Name = "TramPassiveCar"
                },
                new VehicleType
                {
                    Id = 3,
                    Name = "Bus"
                },
                new VehicleType
                {
                    Id = 4,
                    Name = "BusTrailer"
                }
            });

        modelBuilder.Entity<LineType>()
            .HasData(new List<LineType>
            {
                new LineType
                {
                    Id = 1,
                    Name = "TramLine"
                },
                new LineType
                {
                    Id = 2,
                    Name = "BusLine"
                }
            });
    }

    public DbSet<User> Users {get;set;}
    public DbSet<Role> Roles {get;set;}
    public DbSet<SecurityToken> SecurityTokens {get;set;}
    public DbSet<SecurityTokenType> SecurityTokenTypes {get;set;}
    public DbSet<Announcement> Announcements {get;set;}
    public DbSet<AnnouncementType> AnnouncementTypes {get;set;}
    public DbSet<Set> Sets {get;set;}
    public DbSet<Vehicle> Vehicles {get;set;}
    public DbSet<VehicleManufacturer> VehicleManufacturers {get;set;}
    public DbSet<VehicleModel> VehicleModels {get;set;}
    public DbSet<VehicleSet> VehicleSets {get;set;}
    public DbSet<VehicleType> VehicleTypes {get;set;}
    public DbSet<Line> Lines {get;set;}
    public DbSet<LineType> LineTypes {get;set;}
}