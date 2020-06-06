using RMS.InterviewEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.InterviewEngine.Domain.Interfaces
{
    public interface ICandidateInterviewRepository
    {
        IEnumerable<CandidateInterview> GetCandidateInterview();
        void Reject(int candidateInterviewID);
        void Selected(int candidateInterviewID);
    }
}
