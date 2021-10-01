﻿// <auto-generated />
using System;
using BlazorProject.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorProject.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210930120522_initiaal")]
    partial class initiaal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorProject.Shared.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            CreateDate = new DateTime(2021, 9, 30, 14, 5, 20, 940, DateTimeKind.Local).AddTicks(5477),
                            Email = "Eva@pragimtech.com",
                            Password = "1234",
                            Phone = 12233456
                        },
                        new
                        {
                            AccountId = 2,
                            CreateDate = new DateTime(2021, 9, 30, 14, 5, 20, 945, DateTimeKind.Local).AddTicks(4170),
                            Email = "Adam@pragimtech.com",
                            Password = "1234",
                            Phone = 12233456
                        });
                });

            modelBuilder.Entity("BlazorProject.Shared.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("Receiver")
                        .HasColumnType("int");

                    b.Property<int>("Sender")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            MessageText = "Hej med dig, hvad laver du her?",
                            Receiver = 2,
                            Sender = 1,
                            TimeStamp = new DateTime(1999, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 2,
                            MessageText = "Det samme som dig?",
                            Receiver = 1,
                            Sender = 2,
                            TimeStamp = new DateTime(1999, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BlazorProject.Shared.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Postal")
                        .HasColumnType("int");

                    b.HasKey("ProfileId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            ProfileId = 1,
                            AccountId = 1,
                            Alias = "Eva",
                            BirthDate = new DateTime(1970, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = 1,
                            PhotoPath = "esegesg",
                            Postal = 2300
                        },
                        new
                        {
                            ProfileId = 2,
                            AccountId = 2,
                            Alias = "Adam",
                            BirthDate = new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = 0,
                            PhotoPath = "esegesg",
                            Postal = 2300
                        });
                });

            modelBuilder.Entity("BlazorProject.Shared.Message", b =>
                {
                    b.HasOne("BlazorProject.Shared.Profile", null)
                        .WithMany("Messages")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("BlazorProject.Shared.Profile", b =>
                {
                    b.HasOne("BlazorProject.Shared.Account", null)
                        .WithOne("profile")
                        .HasForeignKey("BlazorProject.Shared.Profile", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorProject.Shared.Account", b =>
                {
                    b.Navigation("profile");
                });

            modelBuilder.Entity("BlazorProject.Shared.Profile", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}