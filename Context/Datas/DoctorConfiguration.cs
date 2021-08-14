using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class DoctorConfiguration : PersonConfiguration<Doctor>
    {
        public override void Configure(EntityTypeBuilder<Doctor> builder)
        {
            base.Configure(builder);

            builder.ToTable("doctor");

            builder
                .Property(d => d.Id)
                .HasColumnName("doctor_id");

            builder
                .Property(d => d.Password)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(120)")
                .IsRequired();
        }
    }
}
