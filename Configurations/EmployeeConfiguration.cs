using DataServices.Migrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataServices.Migrations.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);

            builder.Property(p => p.Id)
                .HasColumnType("varchar(5)")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(p => p.Type)
                .HasColumnType("char(2)")
                .IsRequired();
        }
    }
}