using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.InterviewEngine.Domain.Models
{
    public class JobCanditate
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }

        public int JobPostId { get; set; }

        public string CandidateStatus { get; set; }

        public DateTime ReceivedDate { get; set; }
    }
}
