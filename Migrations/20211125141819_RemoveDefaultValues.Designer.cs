﻿// <auto-generated />
using System;
using DutyAndConductorManager.Api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DutyAndConductorManager.Api.Migrations
{
    [DbContext(typeof(ConductorDb))]
    [Migration("20211125141819_RemoveDefaultValues")]
    partial class RemoveDefaultValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-rc.2.21480.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DutyAndConductorManager.Api.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ShiftManager"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Conductor"
                        });
                });

            modelBuilder.Entity("DutyAndConductorManager.Api.Entities.SecurityToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<int>("SecurityTokenTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SecurityTokenTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("SecurityTokens");
                });

            modelBuilder.Entity("DutyAndConductorManager.Api.Entities.SecurityTokenType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecurityTokenTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ActivationToken"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PasswordChangeToken"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ForgotPasswordToken"
                        });
                });

            modelBuilder.Entity("DutyAndConductorManager.Api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTrained")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DutyAndConductorManager.Api.Entities.SecurityToken", b =>
                {
                    b.HasOne("DutyAndConductorManager.Api.Entities.SecurityTokenType", "SecurityTokenType")
                        .WithMany("SecurityTokens")
                        .HasForeignKey("SecurityTokenTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DutyAndConductorManager.Api.Entities.User", "User")
                        .WithMany("SecurityTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SecurityTokenType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DutyAndConductorManager.Api.Entities.User", b =>
                {
                    b.HasOne("DutyAndConductorManager.Api.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DutyAndConductorManager.Api.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DutyAndConductorManager.Api.Entities.SecurityTokenType", b =>
                {
                    b.Navigation("SecurityTokens");
                });

            modelBuilder.Entity("DutyAndConductorManager.Api.Entities.User", b =>
                {
                    b.Navigation("SecurityTokens");
                });
#pragma warning restore 612, 618
        }
    }
}