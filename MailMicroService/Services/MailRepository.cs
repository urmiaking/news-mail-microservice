using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailMicroService.Data;
using MailMicroService.Models;

namespace MailMicroService.Services
{
    public class MailRepository : IMailRepository
    {
        private readonly MailMicroServiceContext _context;

        public MailRepository(MailMicroServiceContext context)
        {
            _context = context;
        }

        public async Task<bool> SendEmail(Mail mail)
        {
            var server = await _context.MailServer.FindAsync(1);
            if (server == null)
            {
                return false;
            }
            try
            {
                using (MailMessage mm = new MailMessage(server.Email, mail.To))
                {
                    mm.Subject = mail.Subject;
                    mm.Body = mail.Body;

                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = server.Host;
                    smtp.EnableSsl = true;

                    NetworkCredential networkCredential = new NetworkCredential(server.Email, server.Password);
                    smtp.Credentials = networkCredential;
                    smtp.Port = server.Port;
                    smtp.Send(mm);

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
