using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RMS.InterviewEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.InterviewEngine.Data.Context
{
    public class InterviewEngineDbContext : DbContext
    {
        public InterviewEngineDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
        }

        public DbSet<JobCanditate> JobCanditates { get; set; }

        public DbSet<CandidateInterview> CandidateInterviews { get; set; }
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
