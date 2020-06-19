using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MailMicroService.Models;

namespace MailMicroService.Data
{
    public class MailMicroServiceContext : DbContext
    {
        public MailMicroServiceContext (DbContextOptions<MailMicroServiceContext> options)
            : base(options)
        {
        }

        public DbSet<MailServer> MailServer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
