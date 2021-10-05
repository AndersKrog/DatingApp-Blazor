using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>().HasKey(e => new {e.MessageId, e.FromId, e.ToId });

            modelBuilder.Entity<Message>().HasOne(e => e.ProfileFrom).WithMany(e => e.MessageTo).HasForeignKey(e => e.FromId);

            modelBuilder.Entity<Message>().HasOne(e => e.ProfileTo).WithMany(e => e.MessageFrom).HasForeignKey(e => e.ToId);

            // Seed Account Table
            modelBuilder.Entity<Account>().HasData(new Account
            {
                AccountId = 1,
                Email = "Eva@pragimtech.com",
                Phone = 12233456,
                Password = "1234",
                CreateDate = DateTime.Now
            }) ;

            modelBuilder.Entity<Profile>().HasData(new Profile
            {
                ProfileId = 1,
                Alias = "Eva",
                Postal = 2300,
                Gender = Gender.Female,
                BirthDate = new DateTime(1970, 10, 5),
                PhotoPath = "esegesg",
                AccountId = 1
            }) ;

            modelBuilder.Entity<Account>().HasData(new Account
            {
                AccountId = 2,
                Email = "Adam@pragimtech.com",
                Phone = 12233456,
                Password = "1234",
                CreateDate = DateTime.Now
            });

            modelBuilder.Entity<Profile>().HasData(new Profile
            {
                ProfileId = 2,
                Alias = "Adam",
                Postal = 2300,
                Gender = Gender.Male,
                BirthDate = new DateTime(1980, 10, 5),
                PhotoPath = "esegesg",
                AccountId = 2
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageText = "Hej med dig, hvad laver du her?",
                MessageId = 1,
                FromId = 1,
                ToId = 2,
                TimeStamp = (new DateTime(1999, 10, 5))
            }) ;

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageText = "Det samme som dig?",
                MessageId = 2,
                FromId = 2,
                ToId = 1,
                TimeStamp = (new DateTime(1999, 10, 6))
            });
        }
    }
}
