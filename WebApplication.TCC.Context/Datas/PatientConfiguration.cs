using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("patient");

            builder
                .Property(p => p.Id)
                .HasColumnName("patient_id");

            builder
                .Property(p => p.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE")
                .IsRequired();

            builder
                .Property(p => p.Height)
                .HasColumnName("height")
                .HasColumnType("NUMERIC(2,2)")
                .IsRequired();

            builder
                .Property(p => p.Weight)
                .HasColumnName("weight")
                .HasColumnType("NUMERIC(3,3)")
                .IsRequired();

            builder
                .Property(p => p.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE")
                .IsRequired();

            builder
                .Property(p => p.UserName)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder
                .Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder
                .Property(p => p.Document)
                .HasColumnName("document")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.HasIndex(p => p.Document).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();
        }
    }
}