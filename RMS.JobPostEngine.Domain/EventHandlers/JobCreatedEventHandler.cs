using RMS.Domain.Core.Bus;
using RMS.JobPostEngine.Domain.Commands;
using RMS.JobPostEngine.Domain.Events;
using RMS.JobPostEngine.Domain.Interfaces;
using RMS.JobPostEngine.Domain.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.JobPostEngine.Domain.EventHandlers
{
    public class JobCreatedEventHandler : IEventHandler<JobCreatedEvent>
    {
        private readonly IJobRepository _jobRepository;

        private readonly IJobPostRepository _jobPostRepository;

        private readonly IExternalSystemRepository _externalSystemRepository;

        private readonly IEventBus _bus;

        public JobCreatedEventHandler(IJobRepository jobRepository,
            IJobPostRepository jobPostRepository,
            IExternalSystemRepository externalSystemRepository,
            IEventBus bus)
        {
            _jobRepository = jobRepository;
            _jobPostRepository = jobPostRepository;
            _externalSystemRepository = externalSystemRepository;
            _bus = bus;
        }

        public Task Handle(JobCreatedEvent @event)
        {
            var jobId = _jobRepository.Add(new Job()
            {
                ManpowerRequestId = @event.FromManpowerRequestId,
                Status = 0
            });

            Log.Information("New Job Created " + jobId);
            _externalSystemRepository.GetSystems().ToList().ForEach(system => {
                var jobPostId = _jobPostRepository.Add(new JobPost()
                {
                    CreatedDate = DateTime.UtcNow,
                    JobId = jobId,
                    ExternalSystemId = system.Id,
                });
                var createJobCommand = new PublishWebsitePostCommand(jobPostId, system.Label, system.Settings, system.IsInternal);

                _bus.SendCommand(createJobCommand);
                Log.Information("Post Request Sent for " + system.Label);
            });

            return Task.CompletedTask;
        }
    }
}
