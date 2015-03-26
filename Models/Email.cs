using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmailSender.Models
{
    public class Email
    {
        [Required]
        [EmailAddress]
        public string To { get; set; }
        public string From { get; set; }
        [Required]
        [StringLength(4)]
        public string Subject { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
