using RMS.CandidateEngine.Data.Context;
using RMS.CandidateEngine.Domain.Interfaces;
using RMS.CandidateEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.CandidateEngine.Data.Repository
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        private CandidateEngineDbContext _ctx;

        public JobCandidateRepository(CandidateEngineDbContext ctx)
        {
            _ctx = ctx;
        }

        public int Add(JobCandidate jobCandidate)
        {
            _ctx.JobCanditates.Add(jobCandidate);
            _ctx.SaveChanges();
            return jobCandidate.Id;
        }

        public JobCandidate GetJobCandidate(int jobPostId, int candidateId)
        {
            return _ctx.JobCanditates.FirstOrDefault(t=> t.JobPostId == jobPostId && t.CandidateId == candidateId);
        }

        public IEnumerable<JobCandidate> GetJobCandidates()
        {
            return _ctx.JobCanditates.ToList();
        }

        public bool Update(JobCandidate jobCandidate)
        {
            _ctx.JobCanditates.Update(jobCandidate);
            _ctx.SaveChanges();
            return true;
        }
    }
}
