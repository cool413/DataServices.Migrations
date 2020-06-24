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


            // builder.HasData
            // (
            //     new CRMProgram
            //     {
            //         Code = "SALMI21",
            //         Name = "工作紀錄",
            //         Hours = 10,
            //         ConfirmationCode = "0000128773_CRM_0001",
            //         CompanyId = 1,
            //         EmployeeId = "09846"
            //     },
            //     new CRMProgram
            //     {
            //         Code = "SALMI30",
            //         Name = "報價單",
            //         Hours = 20,
            //         ConfirmationCode = "0000670228_CRM_0002",
            //         CompanyId = 2,
            //         EmployeeId = "05438"
            //     },
            //     new CRMProgram
            //     {
            //         Code = "REPMI13",
            //         Name = "維修單",
            //         Hours = 30,
            //         ConfirmationCode = "0000129312_CRM_0003",
            //         CompanyId = 3,
            //         EmployeeId = "07056"
            //     }
            // );
        }
    }
}