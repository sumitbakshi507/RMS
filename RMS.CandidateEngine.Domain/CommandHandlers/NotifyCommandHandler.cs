using MediatR;
using RMS.CandidateEngine.Domain.Commands;
using RMS.CandidateEngine.Domain.Events;
using RMS.Domain.Core.Bus;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RMS.CandidateEngine.Domain.CommandHandlers
{
    public class NotifyCommandHandler : IRequestHandler<NotifyCommand, bool>
    {
        private readonly IEventBus _bus;

        public NotifyCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(NotifyCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Handle" + request);
            _bus.Publish(new NotifyPostEvent(request.Email, request.JobPostId, request.CandidateId));
            Log.Information("Handled" + request);
            return Task.FromResult(true);
        }
    }
}
