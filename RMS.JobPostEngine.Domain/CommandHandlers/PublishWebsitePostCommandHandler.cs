using MediatR;
using RMS.Domain.Core.Bus;
using RMS.JobPostEngine.Domain.Commands;
using RMS.JobPostEngine.Domain.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RMS.JobPostEngine.Domain.CommandHandlers
{
    public class PublishWebsitePostCommandHandler : IRequestHandler<PublishWebsitePostCommand, bool>
    {
        private readonly IEventBus _bus;

        public PublishWebsitePostCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(PublishWebsitePostCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Handle" + request);
            _bus.Publish(new PublishWebsitePostEvent(request.JobPostId, request.Label , request.Settings, request.IsInternal));
            Log.Information("Handled" + request);
            return Task.FromResult(true);
        }
    }
}
