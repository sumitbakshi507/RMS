using RMS.InterviewEngine.Data.Context;
using RMS.InterviewEngine.Domain.Interfaces;
using RMS.InterviewEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.InterviewEngine.Data.Repository
{
    public class CandidateInterviewRepository : ICandidateInterviewRepository
    {
        private InterviewEngineDbContext _ctx;

        public CandidateInterviewRepository(InterviewEngineDbContext ctx)
        {
            _ctx = ctx;
        }

        public int Add(CandidateInterview candidateInterview)
        {
            _ctx.CandidateInterviews.Add(candidateInterview);
            _ctx.SaveChanges();
            var candidateInterviewId = candidateInterview.Id;
            return candidateInterviewId;
        }

        public IEnumerable<CandidateInterview> GetCandidateInterview()
        {
            throw new NotImplementedException();
        }

        public void Publish(int candidateInterviewID)
        {
            throw new NotImplementedException();
        }

        public void Reject(int candidateInterviewID)
        {
            throw new NotImplementedException();
        }

        public void Selected(int candidateInterviewID)
        {
            throw new NotImplementedException();
        }
    }
}
