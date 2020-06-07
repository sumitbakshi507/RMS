using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.InterviewEngine.Domain.Models
{
    public class CandidateInterview
    {
        public int Id { get; set; }

        public int Round { get; set; }

        public int JobCandidateId { get; set; }

        public DateTime InterviewDate { get; set; }

        public int InterviewStatus { get; set; }

        public int InterviewType { get; set; }

        public string Feedback { get; set; }

        public string Interviewer { get; set; }
    }
}
