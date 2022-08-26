using EventReg.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;


namespace EventReg.DB.Model
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Password = "Admin12345",
                    Role = "Admin"
                }
            );
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Name = "Programming", Description = "Software", StartDateTime = DateTime.Now.AddDays(4), EndDateTime = DateTime.Now.AddHours(5) },
                 new Event { Id = 2, Name = "Network", Description = "Hardware", StartDateTime = DateTime.Now.AddDays(4), EndDateTime = DateTime.Now.AddDays(7) },
                new Event { Id = 3, Name = "Devpos", Description = "Software", StartDateTime = DateTime.Now.AddDays(2), EndDateTime = DateTime.Now.AddDays(3).AddHours(5) },
                 new Event { Id = 4, Name = "C#", Description = "Software", StartDateTime = DateTime.Now.AddDays(3), EndDateTime = DateTime.Now.AddDays(3).AddHours(5) },
                  new Event { Id = 5, Name = "Java", Description = "Software", StartDateTime = DateTime.Now.AddDays(1), EndDateTime = DateTime.Now.AddDays(1).AddHours(5) },
               new Event { Id = 6, Name = "Python", Description = "Software", StartDateTime = DateTime.Now.AddDays(-1), EndDateTime = DateTime.Now.AddDays(-1).AddHours(5) }
            );
        }
    }
}