using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class TccContext : IdentityDbContext<Doctor>, IDisposable
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        //public TccContext() { }

        public TccContext(DbContextOptions<TccContext> options)
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("User Id=vjpfcgdebywmyu;Password=4e1fe6e1971c1489318c513d1d6b4851b8441b1fbe3795ad73ac42261bc2c678;Host=ec2-34-204-128-77.compute-1.amazonaws.com;Port=5432;Database=dagjn5lbsu5f2r;SSL Mode=Require;Trust Server Certificate=true;");
        //}

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
