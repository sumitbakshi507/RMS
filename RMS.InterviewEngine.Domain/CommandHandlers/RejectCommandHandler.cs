using MediatR;
using RMS.Domain.Core.Bus;
using RMS.InterviewEngine.Domain.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RMS.InterviewEngine.Domain.CommandHandlers
{
    public class RejectCommandHandler : IRequestHandler<RejectCommand, bool>
    {
        private readonly IEventBus _bus;

        public RejectCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(RejectCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Handle" + request);
            //_bus.Publish(new PublishWebsitePostEvent(request.JobPostId, request.Label, request.Settings, request.IsInternal));
            // Do Something
            Log.Information("Handled" + request);
            return Task.FromResult(true);
        }
    }
}
