using RMS.Domain.Core.Bus;
using RMS.InterviewEngine.Domain.Events;
using RMS.InterviewEngine.Domain.Interfaces;
using RMS.InterviewEngine.Domain.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMS.InterviewEngine.Domain.EventHandlers
{
    public class CreateScreeningEventHandler : IEventHandler<CreateScreeningEvent>
    {
        private readonly IEventBus _bus;

        private readonly ICandidateInterviewRepository _candidateInterviewRepository;

        public CreateScreeningEventHandler(IEventBus bus,
            ICandidateInterviewRepository candidateInterviewRepository)
        {
            _bus = bus;
            _candidateInterviewRepository = candidateInterviewRepository;
        }

        public Task Handle(CreateScreeningEvent @event)
        {
            Log.Information("Handle" + @event);
            _candidateInterviewRepository.Add(new CandidateInterview()
            {
                JobCandidateId = @event.JobCandidateId,
                Round = 0,
                InterviewType = InterviewTypeConstant.PreScreening,
                InterviewStatus = InterviewStatusConstant.Pending,
                InterviewDate = DateTime.UtcNow
            });
            return Task.CompletedTask;
        }
    }
}
