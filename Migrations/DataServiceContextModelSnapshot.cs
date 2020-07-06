﻿// <auto-generated />
using System;
using DataServices.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataServices.Migrations.Migrations
{
    [DbContext(typeof(DataServiceContext))]
    partial class DataServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.5.20278.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataServices.Migrations.EntityModels.CRMProgram", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ConfirmationCode")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(4,1)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Code", "ConfirmationCode");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ConfirmationCode");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CRMProgram");

                    b.HasData(
                        new
                        {
                            Code = "SALMI21",
                            ConfirmationCode = "0000128773_CRM_0001",
                            CompanyId = 1,
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(6892),
                            EmployeeId = "09846",
                            Hours = 10m,
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(6903),
                            Name = "工作紀錄"
                        },
                        new
                        {
                            Code = "SALMI30",
                            ConfirmationCode = "0000670228_CRM_0002",
                            CompanyId = 2,
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(7041),
                            EmployeeId = "05438",
                            Hours = 20m,
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(7044),
                            Name = "報價單"
                        },
                        new
                        {
                            Code = "REPMI13",
                            ConfirmationCode = "0000129312_CRM_0003",
                            CompanyId = 3,
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(7049),
                            EmployeeId = "07056",
                            Hours = 30m,
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(7051),
                            Name = "維修單"
                        });
                });

            modelBuilder.Entity("DataServices.Migrations.EntityModels.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "0340",
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 262, DateTimeKind.Local).AddTicks(9248),
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(458),
                            Name = "東洋"
                        },
                        new
                        {
                            Id = 2,
                            Code = "0322",
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(1145),
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(1164),
                            Name = "訊聯"
                        },
                        new
                        {
                            Id = 3,
                            Code = "0217",
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(1173),
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(1175),
                            Name = "雲門"
                        });
                });

            modelBuilder.Entity("DataServices.Migrations.EntityModels.Confirmation", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SystemVersion")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.HasKey("Code");

                    b.HasIndex("CompanyId");

                    b.ToTable("Confirmation");

                    b.HasData(
                        new
                        {
                            Code = "0000128773_CRM_0001",
                            CompanyId = 1,
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3750),
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3761),
                            SystemVersion = "91"
                        },
                        new
                        {
                            Code = "0000670228_CRM_0002",
                            CompanyId = 2,
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3861),
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3866),
                            SystemVersion = "91"
                        },
                        new
                        {
                            Code = "0000129312_CRM_0003",
                            CompanyId = 3,
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3868),
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3869),
                            SystemVersion = "91"
                        });
                });

            modelBuilder.Entity("DataServices.Migrations.EntityModels.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(5)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.HasKey("Id");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = "09846",
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8700),
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8708),
                            Name = "Derek",
                            Type = "PR"
                        },
                        new
                        {
                            Id = "07056",
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8759),
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8760),
                            Name = "Young",
                            Type = "PR"
                        },
                        new
                        {
                            Id = "05438",
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8763),
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8764),
                            Name = "Carter",
                            Type = "SD"
                        });
                });

            modelBuilder.Entity("DataServices.Migrations.EntityModels.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CRMProgramCode")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ConfirmationCode")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("char(8)");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(4,1)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("StarDate")
                        .IsRequired()
                        .HasColumnType("char(8)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ConfirmationCode");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("CRMProgramCode", "ConfirmationCode");

                    b.ToTable("Job");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CRMProgramCode = "SALMI21",
                            ConfirmationCode = "0000128773_CRM_0001",
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2008),
                            EmployeeId = "09846",
                            EndDate = "20200630",
                            Hours = 10m,
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2016),
                            Priority = "2",
                            StarDate = "20200621",
                            Status = "0",
                            Tag = ""
                        },
                        new
                        {
                            Id = 2,
                            CRMProgramCode = "SALMI30",
                            ConfirmationCode = "0000670228_CRM_0002",
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2096),
                            EmployeeId = "05438",
                            EndDate = "20200830",
                            Hours = 20m,
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2097),
                            Priority = "2",
                            StarDate = "20200721",
                            Status = "0",
                            Tag = ""
                        },
                        new
                        {
                            Id = 3,
                            CRMProgramCode = "REPMI13",
                            ConfirmationCode = "0000129312_CRM_0003",
                            CreatedDate = new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2100),
                            EmployeeId = "07056",
                            EndDate = "20201030",
                            Hours = 30m,
                            ModifiedDate = new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2101),
                            Priority = "2",
                            StarDate = "20200921",
                            Status = "0",
                            Tag = ""
                        });
                });

            modelBuilder.Entity("DataServices.Migrations.EntityModels.CRMProgram", b =>
                {
                    b.HasOne("DataServices.Migrations.EntityModels.Company", "Company")
                        .WithMany("CRMPrograms")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataServices.Migrations.EntityModels.Confirmation", "Confirmation")
                        .WithMany("CRMPrograms")
                        .HasForeignKey("ConfirmationCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataServices.Migrations.EntityModels.Employee", "Employee")
                        .WithMany("CRMPrograms")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataServices.Migrations.EntityModels.Confirmation", b =>
                {
                    b.HasOne("DataServices.Migrations.EntityModels.Company", "Company")
                        .WithMany("Confirmations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataServices.Migrations.EntityModels.Job", b =>
                {
                    b.HasOne("DataServices.Migrations.EntityModels.Confirmation", "Confirmation")
                        .WithMany("Jobs")
                        .HasForeignKey("ConfirmationCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataServices.Migrations.EntityModels.Employee", "Employee")
                        .WithMany("Jobs")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("DataServices.Migrations.EntityModels.CRMProgram", "CRMProgram")
                        .WithMany("Jobs")
                        .HasForeignKey("CRMProgramCode", "ConfirmationCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}