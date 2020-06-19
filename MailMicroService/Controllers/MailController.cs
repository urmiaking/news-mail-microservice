using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailMicroService.Models;
using MailMicroService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailMicroService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailRepository _mailRepository;

        public MailController(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(Mail mail)
        {
            var isSent = await _mailRepository.SendEmail(mail);

            if (isSent)
            {
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}