using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Application.Models
{
    public class PublicPostVM
    {
        public int JobPostId { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string CoverLetter { get; set; }

        public string Source { get; set; }

        public IFormFile Document { get; set; }
    }
}
