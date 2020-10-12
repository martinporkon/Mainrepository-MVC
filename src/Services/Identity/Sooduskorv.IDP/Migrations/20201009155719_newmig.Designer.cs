﻿// <auto-generated />
using System;
using Identity.Infra.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Sooduskorv.IDP.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20201009155719_newmig")]
    partial class newmig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("c45f5527-a4b9-4b7a-8bce-058eb6344a31"),
                            ConcurrencyStamp = "fce21a3f-c8a9-4e74-894f-f41ebfc4549e",
                            Type = "given_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Hanna"
                        },
                        new
                        {
                            Id = new Guid("4d501e25-c59a-4e14-999b-e4f7a8884af9"),
                            ConcurrencyStamp = "8f7f1de6-32bb-40d2-95a0-99f787f83108",
                            Type = "family_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Forest"
                        },
                        new
                        {
                            Id = new Guid("886d3806-839a-4f32-b2ca-24cca6e402b9"),
                            ConcurrencyStamp = "5920e04b-4582-4dcb-8dcd-824eee35ed1c",
                            Type = "email",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "hanna@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("c79b1001-8274-4ccd-b880-2511dadecdb8"),
                            ConcurrencyStamp = "5d94d0ce-dafc-4b31-a48d-6282fc972c39",
                            Type = "address",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Tammsaare tee"
                        },
                        new
                        {
                            Id = new Guid("293f4309-441b-414e-af95-1be847af5ce3"),
                            ConcurrencyStamp = "0621dc02-a17e-40c7-8e5e-daf6b5cdf21a",
                            Type = "country",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "somevalue"
                        },
                        new
                        {
                            Id = new Guid("cfd9accb-32be-4ae5-a37b-13a1dc36ef27"),
                            ConcurrencyStamp = "baa5dde6-b19d-479a-98e4-9e3f36679361",
                            Type = "given_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Bob"
                        },
                        new
                        {
                            Id = new Guid("0a88fd07-089c-48d6-bcaf-263a6a11b2e4"),
                            ConcurrencyStamp = "d49272e2-e622-4e35-818f-eb71edddd015",
                            Type = "family_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Oak"
                        },
                        new
                        {
                            Id = new Guid("76e680d5-561c-43dd-a408-da7f117bc044"),
                            ConcurrencyStamp = "7f249742-4aa4-4ab2-a862-ad63139cac83",
                            Type = "email",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "bob@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("2159666b-0223-435e-9429-0f568ba84d63"),
                            ConcurrencyStamp = "80e78942-5894-4581-9bff-855b96cf0aaf",
                            Type = "address",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Ehitajate Tee"
                        },
                        new
                        {
                            Id = new Guid("0703cb80-d683-4ce0-8526-8685a38c4357"),
                            ConcurrencyStamp = "fe978ab2-99ad-4258-9a8a-0233bb59630f",
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
                            ConcurrencyStamp = "8e78d874-f10d-49e9-9c73-a243766ce8ec",
                            Password = "password",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                            Username = "Hanna"
                        },
                        new
                        {
                            Id = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Active = true,
                            ConcurrencyStamp = "ac945bb2-0171-4919-8427-9f3d55db690b",
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
