using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailMicroService.Models
{
    public class Mail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
    }
}
