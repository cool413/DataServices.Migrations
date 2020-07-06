using System;
using DataServices.Migrations.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Migrations.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData
            (
                new Company
                {
                    Id = 1,
                    Name = "東洋",
                    Code = "0340",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Company
                {
                    Id = 2,
                    Name = "訊聯",
                    Code = "0322",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Company
                {
                    Id = 3,
                    Name = "雲門",
                    Code = "0217",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Confirmation>().HasData
            (
                new Confirmation
                {
                    Code = "0000128773_CRM_0001",
                    CompanyId = 1,
                    SystemVersion = "91",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                    
                },
                new Confirmation
                {
                    Code = "0000670228_CRM_0002",
                    CompanyId = 2,
                    SystemVersion = "91",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Confirmation
                {
                    Code = "0000129312_CRM_0003",
                    CompanyId = 3,
                    SystemVersion = "91",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<CRMProgram>().HasData
            (
                new CRMProgram
                {
                    Code = "SALMI21",
                    Name = "工作紀錄",
                    Hours = 10,
                    ConfirmationCode = "0000128773_CRM_0001",
                    CompanyId = 1,
                    EmployeeId = "09846",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new CRMProgram
                {
                    Code = "SALMI30",
                    Name = "報價單",
                    Hours = 20,
                    ConfirmationCode = "0000670228_CRM_0002",
                    CompanyId = 2,
                    EmployeeId = "05438",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new CRMProgram
                {
                    Code = "REPMI13",
                    Name = "維修單",
                    Hours = 30,
                    ConfirmationCode = "0000129312_CRM_0003",
                    CompanyId = 3,
                    EmployeeId = "07056",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Employee>().HasData
            (
                new Employee
                {
                    Id = "09846",
                    Name = "Derek",
                    Type = "PR",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Employee
                {
                    Id = "07056",
                    Name = "Young",
                    Type = "PR",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Employee
                {
                    Id = "05438",
                    Name = "Carter",
                    Type = "SD",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Job>().HasData
            (
                new Job
                {
                    Id = 1,
                    Tag = "",
                    Priority = "2",
                    Status = "0",
                    Hours = 10,
                    StarDate = "20200621",
                    EndDate = "20200630",
                    ConfirmationCode = "0000128773_CRM_0001",
                    CRMProgramCode = "SALMI21",
                    EmployeeId = "09846",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Job
                {
                    Id = 2,
                    Tag = "",
                    Priority = "2",
                    Status = "0",
                    Hours = 20,
                    StarDate = "20200721",
                    EndDate = "20200830",
                    ConfirmationCode = "0000670228_CRM_0002",
                    CRMProgramCode = "SALMI30",
                    EmployeeId = "05438",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Job
                {
                    Id = 3,
                    Tag = "",
                    Priority = "2",
                    Status = "0",
                    Hours = 30,
                    StarDate = "20200921",
                    EndDate = "20201030",
                    ConfirmationCode = "0000129312_CRM_0003",
                    CRMProgramCode = "REPMI13",
                    EmployeeId = "07056",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );
        }
    }
}