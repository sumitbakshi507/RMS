using RMS.JobPostEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Interfaces
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetJobs();
        int Add(Job job);
    }
}
