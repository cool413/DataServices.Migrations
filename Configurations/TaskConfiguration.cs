using DataServices.Migrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataServices.Migrations.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");
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
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.ConfirmationCode)
                .IsRequired();

            builder.HasOne(t => t.CRMProgram)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => new {t.CRMProgramCode, t.ConfirmationCode})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // builder.HasData
            // (
            //     new Task
            //     {
            //         Id = 1,
            //         Tag = "",
            //         Priority = "2",
            //         Status = "0",
            //         Hours = 10,
            //         StarDate = "20200621",
            //         EndDate = "20200630",
            //         ConfirmationCode = "0000128773_CRM_0001",
            //         CRMProgramCode = "SALMI21",
            //         EmployeeId = "09846"
            //     },
            //     new Task
            //     {
            //         Id = 2,
            //         Tag = "",
            //         Priority = "2",
            //         Status = "0",
            //         Hours = 20,
            //         StarDate = "20200721",
            //         EndDate = "20200830",
            //         ConfirmationCode = "0000670228_CRM_0002",
            //         CRMProgramCode = "SALMI30",
            //         EmployeeId = "05438"
            //     },
            //     new Task
            //     {
            //         Id = 3,
            //         Tag = "",
            //         Priority = "2",
            //         Status = "0",
            //         Hours = 30,
            //         StarDate = "20200921",
            //         EndDate = "20201030",
            //         ConfirmationCode = "0000129312_CRM_0003",
            //         CRMProgramCode = "REPMI13",
            //         EmployeeId = "07056"
            //     }
            // );
        }
    }
}