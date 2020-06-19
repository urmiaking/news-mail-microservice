using MailMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailMicroService.Services
{
    public interface IMailRepository
    {
        Task<bool> SendEmail(Mail mail);
    }
}
