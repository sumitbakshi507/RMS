using RMS.CandidateEngine.Data.Context;
using RMS.CandidateEngine.Domain.Interfaces;
using RMS.CandidateEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.CandidateEngine.Data.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private CandidateEngineDbContext _ctx;

        public CandidateRepository(CandidateEngineDbContext ctx)
        {
            _ctx = ctx;
        }

        public int Add(Candidate candidate)
        {
            _ctx.Canditates.Add(candidate);
            _ctx.SaveChanges();
            return candidate.Id;
        }

        public Candidate GetCandidate(string email, string mobile)
        {
            return _ctx.Canditates.FirstOrDefault(c => c.Email == email);
        }


        public Candidate GetCandidate(int candidateId)
        {
            return _ctx.Canditates.FirstOrDefault(c => c.Id == candidateId);
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return _ctx.Canditates.ToList();
        }

        public bool Update(Candidate candidate)
        {
            _ctx.Canditates.Update(candidate);
            _ctx.SaveChanges();
            return true;
        }
    }
}
