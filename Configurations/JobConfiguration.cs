using DataServices.Migrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataServices.Migrations.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Job");
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Tag)
                .HasColumnType("varchar(20)").IsRequired();

            builder.Property(p => p.Priority)
                .HasColumnType("char(1)")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnType("char(1)")
                .IsRequired();

            builder.Property(p => p.Hours)
                .HasColumnType("decimal(4,1)")
                .IsRequired();

            builder.Property(p => p.StarDate)
                .HasColumnType("char(8)")
                .IsRequired();

            builder.Property(p => p.EndDate)
                .HasColumnType("char(8)")
                .IsRequired();

            builder.HasOne(t => t.Confirmation)
                .WithMany(c => c.Jobs)
                .HasForeignKey(t => t.ConfirmationCode)
                .IsRequired();

            builder.HasOne(t => t.CRMProgram)
                .WithMany(c => c.Jobs)
                .HasForeignKey(t => new {t.CRMProgramCode, t.ConfirmationCode})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}