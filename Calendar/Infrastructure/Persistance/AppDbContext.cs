using Calendar.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Person> Person { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.Attendees)
                .WithMany(p => p.Appointments);
        }
    }
}
