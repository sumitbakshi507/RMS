using RMS.JobPostEngine.Data.Context;
using RMS.JobPostEngine.Domain.Interfaces;
using RMS.JobPostEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.JobPostEngine.Data.Repository
{
    public class JobRepository : IJobRepository
    {
        private JobPostEngineDbContext _ctx;

        public JobRepository(JobPostEngineDbContext ctx)
        {
            _ctx = ctx;
        }

        public int Add(Job job)
        {
            _ctx.Add(job);
            _ctx.SaveChanges();
            var jobId = job.Id;

            return jobId;
        }

        public IEnumerable<Job> GetJobs()
        {
            return _ctx.Jobs.ToList();
        }
    }
}
