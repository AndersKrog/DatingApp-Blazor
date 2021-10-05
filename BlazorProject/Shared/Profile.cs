using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
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

        public virtual List<Message> MessageTo { get; set; }
        public virtual List<Message> MessageFrom { get; set; }
    }
}
