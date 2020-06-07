using RMS.CandidateEngine.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMS.CandidateEngine.Application.Contracts
{
    public interface ICandidateService
    {
        IEnumerable<JobCandidateVM> GetAll();

        IEnumerable<JobCandidateVM> GetByJobPost(int jobPostId);

        Task<bool> AddRequest(PublicPostVM request);
    }
}
