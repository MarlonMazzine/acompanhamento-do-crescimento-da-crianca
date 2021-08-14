using Microsoft.EntityFrameworkCore;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class TccContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User Id=kopdipvnwbekfq;Password=e84d9e388d48049bbf28ada393565da070708a44c7a25b13fd5670aa54b6aa54;Host=ec2-44-196-68-164.compute-1.amazonaws.com;Port=5432;Database=duq2h90gskcja;SSL Mode=Require;Trust Server Certificate=true;");//Port=5432;Database=duq2h90gskcja;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorPatientConfiguration());
        }
    }
}
