using RMS.JobPostEngine.Data.Context;
using RMS.JobPostEngine.Domain.Interfaces;
using RMS.JobPostEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.JobPostEngine.Data.Repository
{
    public class JobPostRepository : IJobPostRepository
    {
        private JobPostEngineDbContext _ctx;

        public JobPostRepository(JobPostEngineDbContext ctx)
        {
            _ctx = ctx;
        }

        public int Add(JobPost job)
        {
            _ctx.JobPosts.Add(job);
            
            _ctx.SaveChanges();
            var postId = job.Id;
            return postId;
        }

        public IEnumerable<JobPost> GetJobPosts()
        {
            return _ctx.JobPosts.ToList();
        }

        public void Publish(int jobPostId)
        {
            var post = _ctx.JobPosts.FirstOrDefault(t => t.Id == jobPostId);
            post.PostDate = DateTime.UtcNow;
            _ctx.SaveChanges();
        }
    }
}
