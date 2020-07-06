﻿using System;
using System.Linq;
using DataServices.Migrations.Configurations;
using DataServices.Migrations.EntityModels;
 using DataServices.Migrations.Extensions;
 using DataServices.Migrations.Interfaces;
using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.Configuration;

 namespace DataServices.Migrations
{
    public class DataServiceContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Confirmation> Confirmations { get; set; }
        public DbSet<CRMProgram> CRMProgram { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Job> Task { get; set; }

        // public DataServiceContext(DbContextOptions options)
        //     : base(options)
        // {
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        
            var connectionString = configuration.GetConnectionString("DefaultConnection");
        
            optionsBuilder.UseSqlServer(
                connectionString,
                options => options.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new ConfirmationConfiguration());
            modelBuilder.ApplyConfiguration(new CRMProgramConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.Seed();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var added = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in added)
            {
                if (entity is ITrack track)
                {
                    track.CreatedDate = DateTime.Now;
                }
            }

            var modified = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in modified)
            {
                if (entity is ITrack track)
                {
                    track.ModifiedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}