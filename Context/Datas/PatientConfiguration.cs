using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class PatientConfiguration : PersonConfiguration<Patient>
    {
        public override void Configure(EntityTypeBuilder<Patient> builder)
        {
            base.Configure(builder);

            builder.ToTable("patient");

            builder
                .Property(c => c.Id)
                .HasColumnName("patient_id");

            builder
                .Property(c => c.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE")
                .IsRequired();

            builder
                .Property(c => c.Height)
                .HasColumnName("height")
                .HasColumnType("NUMERIC(2,2)")
                .IsRequired();

            builder
                .Property(c => c.Weight)
                .HasColumnName("weight")
                .HasColumnType("NUMERIC(3,3)")
                .IsRequired();

            builder
                .Property(c => c.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE")
                .IsRequired();
        }
    }
}