using Microsoft.EntityFrameworkCore.Internal;
using RMS.CandidateEngine.Application.Contracts;
using RMS.CandidateEngine.Application.Models;
using RMS.CandidateEngine.Domain.Commands;
using RMS.CandidateEngine.Domain.Interfaces;
using RMS.CandidateEngine.Domain.Models;
using RMS.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RMS.CandidateEngine.Application.Services
{
    public class CandidateService: ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IJobCandidateRepository _jobCandidateRepository;
        private readonly IEventBus _bus;

        public CandidateService(
            ICandidateRepository candidateRepository,
            IJobCandidateRepository jobCandidateRepository,
            IEventBus bus)
        {
            _candidateRepository = candidateRepository;
            _jobCandidateRepository = jobCandidateRepository;
            _bus = bus;
        }

        public IEnumerable<JobCandidateVM> GetByJobPost(int jobPostId)
        {
            var returnData = new List<JobCandidateVM>();
            var jobCandidates = new List<JobCandidate>();
            if (jobPostId == 0) {
                jobCandidates = _jobCandidateRepository.GetJobCandidates().Where(t => t.JobPostId == jobPostId).ToList();
            }
            else {
                jobCandidates = _jobCandidateRepository.GetJobCandidates().ToList();
            }
            var candidates = _candidateRepository.GetCandidates().ToList();

            jobCandidates.ForEach(jc => {
                var c = candidates.FirstOrDefault(t => t.Id == jc.CandidateId);
                var vm = new JobCandidateVM()
                {
                    Id = jc.Id,
                    CandidateId = jc.CandidateId,
                    CandidateStatus = jc.CandidateStatus,
                    JobPostId = jc.JobPostId,
                    ReceivedDate = jc.ReceivedDate,
                    CoverLetter = c.CoverLetter,
                    Email = c.Email,
                    Mobile = c.Mobile,
                    ResumeUrl = c.ResumeUrl
                };
            });

            return returnData;
        }

        public IEnumerable<JobCandidateVM> GetAll()
        {
            return GetByJobPost(0);
        }

        public async Task<bool> AddRequest(PublicPostVM request)
        {
            const string filePath = "./Files/";
            if (request.Document != null && request.Document.Length > 0)
            {
                var fileName = request.Document.FileName;
                
                var randomName = Guid.NewGuid().ToString().Replace("-", "");
                using (var stream = new FileStream($"{filePath}{randomName}", FileMode.Create))
                {
                    await request.Document.CopyToAsync(stream);
                }
                var resumeReceivedCommand = new ResumeReceivedCommand(
                    request.JobPostId,
                    request.Email,
                    request.Mobile,
                    request.CoverLetter,
                    fileName,
                    randomName,
                    request.Source
                );

                await _bus.SendCommand(resumeReceivedCommand);
            } 
            else
            {
                throw new HttpRequestException("Resume Missing");
            }

            return true;
        }
    }
}
