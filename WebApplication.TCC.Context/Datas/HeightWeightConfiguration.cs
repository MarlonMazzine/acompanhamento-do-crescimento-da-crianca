using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    internal class HeightWeightConfiguration : IEntityTypeConfiguration<HeightWeight>
    {
        public void Configure(EntityTypeBuilder<HeightWeight> builder)
        {
            builder.ToTable("patient_height_weight");

            builder
                .Property(p => p.Id)
                .HasColumnName("height_weight_id");

            builder
                .Property(p => p.Height)
                .HasColumnName("height")
                .HasColumnType("NUMERIC")
                .IsRequired();

            builder
                .Property(p => p.Weight)
                .HasColumnName("weight")
                .HasColumnType("NUMERIC")
                .IsRequired();

            builder
                .Property(p => p.PatientId)
                .HasColumnName("patient_id")
                .HasColumnType("TEXT")
                .IsRequired();
        }
    }
}