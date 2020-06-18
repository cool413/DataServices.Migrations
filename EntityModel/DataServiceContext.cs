﻿﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataServices.Migrations.EntityModel
{
    public class DataServiceContext: DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Confirmation> Confirmations { get; set; }
        public DbSet<CRMProgram> CRMProgram { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Task> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            optionsBuilder.UseSqlServer(connectionString);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CRMProgram>()
                .HasKey(c => new { c.Code, c.ConfirmationCode });
        }
    }
}