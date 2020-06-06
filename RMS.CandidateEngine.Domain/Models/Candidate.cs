using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Domain.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string CoverLetter { get; set; }

        public string ResumeUrl { get; set; }
    }
}
