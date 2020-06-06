using RMS.CandidateEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Domain.Interfaces
{
    public interface IJobCandidateRepository
    {
        IEnumerable<JobCandidate> GetJobCandidates();

        JobCandidate GetJobCandidate(int jobPostId, int candidateId);

        int Add(JobCandidate jobCandidate);

        bool Update(JobCandidate jobCandidate);
    }
}
