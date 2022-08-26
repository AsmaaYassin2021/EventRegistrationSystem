using EventReg.Common;
using EventReg.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventReg.DB.Model
{
    public class EventDBContext : DbContext
    {
        public EventDBContext(DbContextOptions<EventDBContext> options) : base(options)
        {
           

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().ToTable("Event").HasKey(m => m.Id);
            //how do we extend the data model?
            modelBuilder.Entity<Event>()
        .HasDiscriminator<string>("EventType")
        .HasValue<Event>("Event")
        .HasValue<NewInfoForEvent>("NewInfoForEvent");
       
            modelBuilder.Entity<Registration>().ToTable("Registration").HasKey(m => m.Id);
            modelBuilder.Entity<User>();

            modelBuilder.Seed();
           
        }
    }
}

