using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(new Doctor
            {
                DoctorId = 123,
                UserName = "admin",
                Email = "admin@example.org",
                PasswordHash = "AQAAAAEAACcQAAAAED0tb8N23CW0B1uLCmdSzL1kfJKD1NqSU6VxzkJ/ATsHW8awVv+bBSmNiACpNR9Iqw==",
                Document = "12165466733",
            });

            builder.ToTable("doctor");

            builder
                .Property(d => d.DoctorId)
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
        }
    }
}
