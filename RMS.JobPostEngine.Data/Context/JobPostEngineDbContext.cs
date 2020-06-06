using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RMS.JobPostEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Data.Context
{
    public class JobPostEngineDbContext: DbContext
    {
        public JobPostEngineDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
        }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobPost> JobPosts { get; set; }

        public DbSet<ExternalSystem> ExternalSystems { get; set; }
    }

    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
