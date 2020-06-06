using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RMS.RequestEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.RequestEngine.Data.Context
{
    public class RequestEngineDbContext : DbContext
    {
        public RequestEngineDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
        }

        // Add DBSet<Table> Properties Here 
        public DbSet<ManpowerRequest> ManpowerRequests { get; set; }
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
