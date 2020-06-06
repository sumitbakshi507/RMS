using RMS.JobPostEngine.Data.Context;
using RMS.JobPostEngine.Domain.Interfaces;
using RMS.JobPostEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.JobPostEngine.Data.Repository
{
    public class ExternalSystemRepository : IExternalSystemRepository
    {
        private JobPostEngineDbContext _ctx;

        public ExternalSystemRepository(JobPostEngineDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ExternalSystem> GetSystems()
        {
            return _ctx.ExternalSystems.ToList();
        }
    }
}
