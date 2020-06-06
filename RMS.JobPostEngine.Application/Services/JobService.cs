using RMS.Domain.Core.Bus;
using RMS.JobPostEngine.Application.Contracts;
using RMS.JobPostEngine.Domain.Interfaces;
using RMS.JobPostEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IEventBus _bus;

        public JobService(IJobRepository jobRepository, IEventBus bus)
        {
            _jobRepository = jobRepository;
            _bus = bus;
        }

        public IEnumerable<Job> GetJobs()
        {
            return this.GetJobs();
        }
    }
}
