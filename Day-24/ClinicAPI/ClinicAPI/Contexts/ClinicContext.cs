using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Contexts
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                Id = 1,
                Name = "Ramu",
                Specialization = "General Physician",
                Experience = 5
            },
            new Doctor
            {
                Id = 2,
                Name = "Somu",
                Specialization = "Dermatologist",
                Experience = 10
            }
            );
        }

    }
}
