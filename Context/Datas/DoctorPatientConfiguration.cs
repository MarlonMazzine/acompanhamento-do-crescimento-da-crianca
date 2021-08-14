using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class DoctorPatientConfiguration : IEntityTypeConfiguration<DoctorPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorPatient> builder)
        {
            builder.ToTable("doctor_patient");

            builder
                .Property(dp => dp.Id)
                .HasColumnName("doctor_patient_id");

            builder.Property<long>("doctor_id");

            builder
                .Property(dp => dp.PatientId)
                .HasColumnName("patient_id");

            builder
                .HasOne(dp => dp.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey("doctor_id");

            builder
                .HasOne(dp => dp.Patient)
                .WithOne(d => d.Doctor)
                .HasForeignKey<DoctorPatient>(dp => dp.PatientId);
        }
    }
}
