using RMS.CandidateEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Domain.Interfaces
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetCandidates();

        Candidate GetCandidate(string email, string mobile);

        int Add(Candidate candidate);

        bool Update(Candidate candidate);
    }
}
