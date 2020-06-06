using RMS.JobPostEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Application.Contracts
{
    public interface IJobService
    {
        IEnumerable<Job> GetJobs();
    }
}
