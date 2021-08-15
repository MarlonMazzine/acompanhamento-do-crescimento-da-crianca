using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("doctor");

            builder
                .Property(d => d.Id)
                .HasColumnName("doctor_id");

            builder
                .Property(d => d.PasswordHash)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(120)")
                .IsRequired();

            builder
                .Property(c => c.UserName)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder
                .Property(c => c.Document)
                .HasColumnName("document")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.HasIndex(d => d.Document).IsUnique();
            builder.HasIndex(d => d.Email).IsUnique();
        }
    }
}
