using DataServices.Migrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataServices.Migrations.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasColumnType("varchar(10)").IsRequired();

            builder.Property(p => p.Code)
                .HasColumnType("varchar(4)").IsRequired();

            // builder.HasData
            // (
            //     new Company
            //     {
            //         Id = 1,
            //         Name = "東洋",
            //         Code = "0340"
            //     },
            //     new Company
            //     {
            //         Id = 2,
            //         Name = "訊聯",
            //         Code = "0322"
            //     },
            //     new Company
            //     {
            //         Id = 3,
            //         Name = "雲門",
            //         Code = "0217"
            //     }
            // );
        }
    }
}