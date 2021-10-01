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

        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Department> Departments { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                MessageId = 1,
                MessageText = "Hej med dig, hvad laver du her?",
                Sender = 1,
                Receiver = 2,
                TimeStamp = (new DateTime(1999, 10, 5))
            }) ;

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = 2,
                MessageText = "Det samme som dig?",
                Sender = 2,
                Receiver = 1,
                TimeStamp = (new DateTime(1999, 10, 6))
            });
        }
    }
}
