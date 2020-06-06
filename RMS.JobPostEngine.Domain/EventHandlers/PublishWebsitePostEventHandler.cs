using RMS.Domain.Core.Bus;
using RMS.JobPostEngine.Domain.Events;
using RMS.JobPostEngine.Domain.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading.Tasks;

namespace RMS.JobPostEngine.Domain.EventHandlers
{
    public class PublishWebsitePostEventHandler : IEventHandler<PublishWebsitePostEvent>
    {
        private readonly IJobPostRepository _jobPostRepository;
        public PublishWebsitePostEventHandler(
                   IJobPostRepository jobPostRepository)
        {
            _jobPostRepository = jobPostRepository;
        }

        public Task Handle(PublishWebsitePostEvent @event)
        {
            Log.Information("Publishing " + @event.Label + " for " + @event.JobPostId);

            _jobPostRepository.Publish(@event.JobPostId);

            Log.Information("Publishing Completed " + @event.Label);
            return Task.CompletedTask;
        }
    }
}
