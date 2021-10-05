using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class Message
    { 
        public int MessageId { get; set; } 
        
        public string MessageText { get; set; }
        public DateTime TimeStamp { get; set; }

        public int FromId { get; set; }         // foreign key
        public int ToId { get; set; }       // foreign key

        public virtual Profile ProfileFrom { get; set; }
        public virtual Profile ProfileTo { get; set; }


    }
}
