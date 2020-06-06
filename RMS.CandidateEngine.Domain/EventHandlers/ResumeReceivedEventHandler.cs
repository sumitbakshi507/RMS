using RMS.CandidateEngine.Domain.Events;
using RMS.CandidateEngine.Domain.Interfaces;
using RMS.CandidateEngine.Domain.Models;
using RMS.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.CandidateEngine.Domain.EventHandlers
{
    public class ResumeReceivedEventHandler : IEventHandler<ResumeReceivedEvent>
    {
        private readonly ICandidateRepository _candidateRepository;

        private readonly IJobCandidateRepository _jobCandidateRepository;

        private readonly IEventBus _bus;

        public ResumeReceivedEventHandler(ICandidateRepository candidateRepository,
            IJobCandidateRepository jobCandidateRepository,
            IEventBus bus)
        {
            _candidateRepository = candidateRepository;
            _jobCandidateRepository = jobCandidateRepository;
            _bus = bus;
        }

        public Task Handle(ResumeReceivedEvent @event)
        {
            var candidate = _candidateRepository.GetCandidate(@event.Email, @event.Mobile);
            int candidateId;
            if (candidate == null)
            {
                candidateId = _candidateRepository.Add(new Candidate()
                {
                    Email = @event.Email,
                    Mobile = @event.Mobile,
                    ResumeUrl = @event.ResumeUrl
                });
            }
            else {
                candidate.ResumeUrl = @event.ResumeUrl;
                candidateId = candidate.Id;
                _candidateRepository.Update(candidate);
            }

            var jobCandidate = _jobCandidateRepository.GetJobCandidate(@event.JobPostId, candidateId);
            int jobCandidateId;
            if (jobCandidate == null) {
                jobCandidateId = _jobCandidateRepository.Add(new JobCandidate()
                {
                    CandidateId = candidateId,
                    JobPostId = @event.JobPostId,
                    CandidateStatus = CandidateStatusEnum.New
                });
            }

            return Task.CompletedTask;
        }
    }
}
