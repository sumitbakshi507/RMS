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
    public class ResumeReceivedCommandHandler : IRequestHandler<ResumeReceivedCommand, bool>
    {
        private readonly IEventBus _bus;

        public ResumeReceivedCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(ResumeReceivedCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Handle" + request);
            
            _bus.Publish(new ResumeReceivedEvent(
                request.JobPostId, 
                request.Email, 
                request.Mobile, 
                request.RandomName,
                request.Source,
                request.FileName,
                request.CoverLetter));
            Log.Information("Handled" + request);
            return Task.FromResult(true);
        }
    }
}
