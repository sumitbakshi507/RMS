using RMS.JobPostEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Interfaces
{
    public interface IJobPostRepository
    {
        IEnumerable<JobPost> GetJobPosts();
        int Add(JobPost job);
        void Publish(int jobPostId);
    }
}
