using RMS.CandidateEngine.Domain.Commands;
using RMS.CandidateEngine.Domain.Events;
using RMS.CandidateEngine.Domain.Interfaces;
using RMS.CandidateEngine.Domain.Models;
using RMS.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.IO;
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
            const string filePath = "./Files/";
            var candidate = _candidateRepository.GetCandidate(@event.Email, @event.Mobile);
            int candidateId;
            if (candidate == null)
            {
                candidateId = _candidateRepository.Add(new Candidate()
                {
                    Email = @event.Email,
                    Mobile = @event.Mobile,
                    ResumeUrl = @event.ResumeUrl,
                    CoverLetter = @event.CoverLetter
                });
            }
            else {
                candidate.ResumeUrl = @event.ResumeUrl;
                candidateId = candidate.Id;
                _candidateRepository.Update(candidate);
            }
            if (!Directory.Exists($"{filePath}{candidateId}"))
            {
                Directory.CreateDirectory($"{filePath}{candidateId}");
            }

            File.Move($"{filePath}{@event.ResumeUrl}", $"{filePath}{candidateId}/{@event.FileName}", true);

            candidate = _candidateRepository.GetCandidate(candidateId);
            candidate.ResumeUrl = $"{filePath}{candidateId}/{@event.FileName}";

            _candidateRepository.Update(candidate);

            var jobCandidate = _jobCandidateRepository.GetJobCandidate(@event.JobPostId, candidateId);
            int jobCandidateId;
            if (jobCandidate == null) {
                jobCandidateId = _jobCandidateRepository.Add(new JobCandidate()
                {
                    CandidateId = candidateId,
                    JobPostId = @event.JobPostId,
                    CandidateStatus = CandidateStatusEnum.New,
                    Source = @event.Source,
                    ReceivedDate = DateTime.UtcNow
                });

                var createScreeningCommand = new CreateScreeningCommand(jobCandidateId);

                _bus.SendCommand(createScreeningCommand);
            }

            return Task.CompletedTask;
        }
    }
}
