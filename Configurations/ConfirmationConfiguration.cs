using System;
using DataServices.Migrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataServices.Migrations.Configurations
{
    public class ConfirmationConfiguration : IEntityTypeConfiguration<Confirmation>
    {
        public void Configure(EntityTypeBuilder<Confirmation> builder)
        {
            builder.ToTable("Confirmation");
            builder.HasKey(c => c.Code);

            builder.Property(p => p.Code)
                .HasColumnType("varchar(30)").IsRequired();

            builder.Property(p => p.SystemVersion)
                .HasColumnType("char(2)").IsRequired();

            builder.HasOne(c => c.Company)
                .WithMany(c => c.Confirmations)
                .HasForeignKey(c => c.CompanyId)
                .IsRequired();

            // builder.HasData
            // (
            //     new Confirmation
            //     {
            //         Code = "0000128773_CRM_0001",
            //         CompanyId = 1,
            //         SystemVersion = "91",
            //     },
            //     new Confirmation
            //     {
            //         Code = "0000670228_CRM_0002",
            //         CompanyId = 2,
            //         SystemVersion = "91",
            //     },
            //     new Confirmation
            //     {
            //         Code = "0000129312_CRM_0003",
            //         CompanyId = 3,
            //         SystemVersion = "91",
            //     }
            // );
        }
    }
}