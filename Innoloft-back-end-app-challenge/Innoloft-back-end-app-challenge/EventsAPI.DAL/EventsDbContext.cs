using EventsAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.DAL
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext()
            :base()
        {

        }

        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventsRegistrations { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<InvitedUsers> InvitedUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(EventsDbContext)));

        }
    }
}
