using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class TccContext : IdentityDbContext<Doctor>
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public TccContext(DbContextOptions<TccContext> options)
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>()
                .HasIndex(b => b.Document)
                .IsUnique();

            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorPatientConfiguration());
        }
    }
}
