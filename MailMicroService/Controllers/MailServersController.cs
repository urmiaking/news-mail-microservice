using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailMicroService.Data;
using MailMicroService.Models;

namespace MailMicroService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MailServersController : ControllerBase
    {
        private readonly MailMicroServiceContext _context;

        public MailServersController(MailMicroServiceContext context)
        {
            _context = context;
        }

        // GET: api/MailServers/GetMailServer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MailServer>>> GetMailServer()
        {
            return await _context.MailServer.ToListAsync();
        }

        // GET: api/MailServers/GetMailServer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MailServer>> GetMailServer(int id)
        {
            var mailServer = await _context.MailServer.FindAsync(id);

            if (mailServer == null)
            {
                return NotFound();
            }

            return mailServer;
        }

        // PUT: api/MailServers/PutMailServer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMailServer(int id, MailServer mailServer)
        {
            if (id != mailServer.Id)
            {
                return BadRequest();
            }

            _context.Entry(mailServer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailServerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MailServers/PostMailServer
        [HttpPost]
        public async Task<ActionResult<MailServer>> PostMailServer(MailServer mailServer)
        {
            _context.MailServer.Add(mailServer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMailServer", new { id = mailServer.Id }, mailServer);
        }

        // DELETE: api/MailServers/DeleteMailServer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MailServer>> DeleteMailServer(int id)
        {
            var mailServer = await _context.MailServer.FindAsync(id);
            if (mailServer == null)
            {
                return NotFound();
            }

            _context.MailServer.Remove(mailServer);
            await _context.SaveChangesAsync();

            return mailServer;
        }

        private bool MailServerExists(int id)
        {
            return _context.MailServer.Any(e => e.Id == id);
        }
    }
}
