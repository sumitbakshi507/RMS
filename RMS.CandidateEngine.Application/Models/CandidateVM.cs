using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Application.Models
{
    public class JobCandidateVM
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }

        public int JobPostId { get; set; }

        public string CandidateStatus { get; set; }

        public DateTime ReceivedDate { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string CoverLetter { get; set; }

        public string ResumeUrl { get; set; }
    }
}
