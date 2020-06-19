using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailMicroService.Models
{
    public class MailServer
    {
        public int Id { get; set; }
        public string ServerType { get; set; }
        public string Email { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
    }
}
