﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Sooduskorv.IDP.Data;

namespace Sooduskorv.IDP.Migrations
{
    [DbContext(typeof(IdentityApplicationDbContext))]
    partial class IdentityApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Identity.Data.Entities.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");

                    b.HasData(
                        new
                        {
                            Id = new Guid("35711de4-6997-418e-8472-fbd81bff703a"),
                            ConcurrencyStamp = "c30f46ff-a528-463b-a78f-7f5a5f448445",
                            Type = "given_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Hanna"
                        },
                        new
                        {
                            Id = new Guid("fcc6e650-4f33-4303-afd3-b2fc0b0523f6"),
                            ConcurrencyStamp = "f7b6ab16-c0fa-4205-871b-246b73107fbb",
                            Type = "family_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Forest"
                        },
                        new
                        {
                            Id = new Guid("62122e44-fb77-410d-9474-439d50fbbc79"),
                            ConcurrencyStamp = "a910132e-560d-4570-8b34-8ff94473db45",
                            Type = "email",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "hanna@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("b1509505-347c-4f6d-add7-e292b3e64733"),
                            ConcurrencyStamp = "01270c3f-1851-4863-a987-0f731c49688a",
                            Type = "address",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Tammsaare tee"
                        },
                        new
                        {
                            Id = new Guid("f485d136-9d26-485b-b466-c127d28f39fa"),
                            ConcurrencyStamp = "7acfc1bb-0c4f-4376-97c1-14ca479badb5",
                            Type = "country",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "somevalue"
                        },
                        new
                        {
                            Id = new Guid("5a21b1dd-fdb2-46b8-8739-90dfec33807b"),
                            ConcurrencyStamp = "3fbbe249-83f5-4d32-883c-9a3bbda03b84",
                            Type = "given_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Bob"
                        },
                        new
                        {
                            Id = new Guid("715aa646-8c22-4c0c-a88d-52552c8d888c"),
                            ConcurrencyStamp = "2e0e4fd6-caa3-4868-8536-c3fb51c2acc6",
                            Type = "family_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Oak"
                        },
                        new
                        {
                            Id = new Guid("c2c7f6c8-3ac7-480d-9018-9ee6633cf3dc"),
                            ConcurrencyStamp = "b4178f30-b851-4dce-9235-d46b1c658a8b",
                            Type = "email",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "bob@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("85edb1a4-4ba4-47e5-9c2d-2bc0bd5cb7da"),
                            ConcurrencyStamp = "633f31bb-ab9c-4e1a-9c89-c9dba6233df9",
                            Type = "address",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Ehitajate Tee"
                        },
                        new
                        {
                            Id = new Guid("a275d158-68d2-42d3-84ef-1d53e19ef101"),
                            ConcurrencyStamp = "9161e7cf-99fd-4844-9a2b-291748ce23e2",
                            Type = "country",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "somevalue"
                        });
                });

            modelBuilder.Entity("Identity.Data.Entities.UserData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("SecurityCodeExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Subject")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Active = true,
                            ConcurrencyStamp = "23fa10b7-9015-4599-b6f1-aebb402d85d2",
                            Password = "password",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                            Username = "Hanna"
                        },
                        new
                        {
                            Id = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Active = true,
                            ConcurrencyStamp = "d03afd80-e8c3-4654-82db-ab919f954374",
                            Password = "password",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                            Username = "Bob"
                        });
                });

            modelBuilder.Entity("Identity.Data.Entities.UserClaim", b =>
                {
                    b.HasOne("Identity.Data.Entities.UserData", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
