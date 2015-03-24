using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSender.Models
{
    public class Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
