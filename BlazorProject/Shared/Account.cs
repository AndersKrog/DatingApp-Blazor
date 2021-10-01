using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class Account
    {
        public int AccountId { get; set; }
        [Required]
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }

        public Profile profile { get; set; }
    }

    public class Profile 
    {
        public int ProfileId { get; set; }
        [Required]
        public string Alias { get; set; }
        public int Postal { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoPath { get; set; }
        public int AccountId { get; set; } // foreign key

        public List<Message> Messages { get; set; }
    }

    public class Message
    { 
        public int MessageId { get; set; } 
        public string MessageText { get; set; }
        public int Sender { get; set; }         // foreign key
        public int Receiver { get; set; }       // foreign key
        public DateTime TimeStamp { get; set; }
    }
}
