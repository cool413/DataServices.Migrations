using DataServices.Migrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataServices.Migrations.Configurations
{
    public class CRMProgramConfiguration : IEntityTypeConfiguration<CRMProgram>
    {
        public void Configure(EntityTypeBuilder<CRMProgram> builder)
        {
            builder.ToTable("CRMProgram");
            builder.HasKey(c => new {c.Code, c.ConfirmationCode});

            builder.Property(p => p.Code)
                .HasColumnType("varchar(10)").IsRequired();

            builder.Property(p => p.Name)
                .HasColumnType("varchar(10)").IsRequired();

            builder.Property(p => p.Hours)
                .HasColumnType("decimal(4,1)").IsRequired();

            builder.HasOne(c => c.Confirmation)
                .WithMany(c => c.CRMPrograms)
                .HasForeignKey(c => c.ConfirmationCode)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(c => c.Company)
                .WithMany(c => c.CRMPrograms)
                .HasForeignKey(c => c.CompanyId)
                .IsRequired();

            builder.HasOne(c => c.Employee)
                .WithMany(c => c.CRMPrograms)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();
        }
    }
}