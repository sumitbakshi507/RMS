using RMS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RMS.CandidateEngine.Domain.Events
{
    public class ResumeReceivedEvent: Event
    {
        public int JobPostId { get; private set; }

        public string Email { get; private set; }

        public string Mobile { get; private set; }

        public string ResumeUrl { get; private set; }

        public string FileName { get; private set; }

        public string Source { get; private set; }

        public string CoverLetter { get; private set; }

        public ResumeReceivedEvent(
            int jobPostId,
            string email,
            string mobile,
            string resumeUrl,
            string source,
            string fileName,
            string coverLetter)
        {
            JobPostId = jobPostId;
            Email = email;
            Mobile = mobile;
            ResumeUrl = resumeUrl;
            Source = source;
            FileName = fileName;
            CoverLetter = coverLetter;
        }
    }
}
