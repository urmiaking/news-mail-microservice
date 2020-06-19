using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailMicroService.Models;

namespace MailMicroService.Data
{
    public static class DataGenerator
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailServer>()
                .HasData(new MailServer()
                {
                    Id = 1,
                    Email = "masoud.xpress@gmail.com",
                    Host = "smtp.gmail.com",
                    Port = 587,
                    ServerType = "gmail",
                    Password = "MASOUD7559"
                });
        }
    }
}
