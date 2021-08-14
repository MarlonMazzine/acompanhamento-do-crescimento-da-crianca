using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Context.Datas
{
    public class PersonConfiguration<T> : IEntityTypeConfiguration<T> where T : Person
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .Property(c => c.Name)
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
