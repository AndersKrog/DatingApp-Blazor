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
}
