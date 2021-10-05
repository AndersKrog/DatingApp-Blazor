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
    [Migration("20211005075752_initial")]
    partial class initial
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
                            CreateDate = new DateTime(2021, 10, 5, 9, 57, 52, 248, DateTimeKind.Local).AddTicks(7620),
                            Email = "Eva@pragimtech.com",
                            Password = "1234",
                            Phone = 12233456
                        },
                        new
                        {
                            AccountId = 2,
                            CreateDate = new DateTime(2021, 10, 5, 9, 57, 52, 252, DateTimeKind.Local).AddTicks(6410),
                            Email = "Adam@pragimtech.com",
                            Password = "1234",
                            Phone = 12233456
                        });
                });

            modelBuilder.Entity("BlazorProject.Shared.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<int>("FromId")
                        .HasColumnType("int");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId", "FromId", "ToId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 0,
                            FromId = 1,
                            ToId = 2,
                            MessageText = "Hej med dig, hvad laver du her?",
                            TimeStamp = new DateTime(1999, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 0,
                            FromId = 2,
                            ToId = 1,
                            MessageText = "Det samme som dig?",
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
                    b.HasOne("BlazorProject.Shared.Profile", "ProfileFrom")
                        .WithMany("MessageTo")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorProject.Shared.Profile", "ProfileTo")
                        .WithMany("MessageFrom")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileFrom");

                    b.Navigation("ProfileTo");
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
                    b.Navigation("MessageFrom");

                    b.Navigation("MessageTo");
                });
#pragma warning restore 612, 618
        }
    }
}
