using RMS.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Domain.Commands
{
    public class ResumeReceivedCommand : Command
    {
        public string Email { get; protected set; }

        public string Mobile { get; protected set; }

        public int JobPostId { get; protected set; }

        public string FileName { get; protected set; }

        public string RandomName { get; protected set; }

        public string CoverLetter { get; protected set; }

        public string Source { get; protected set; }

        public ResumeReceivedCommand(
            int jobPostId,
            string email,
            string mobile,
            string coverLetter,
            string fileName,
            string randomName,
            string source
            )
        {
            JobPostId = jobPostId;
            Email = email;
            Mobile = mobile;
            CoverLetter = coverLetter;
            FileName = fileName;
            RandomName = randomName;
            Source = source;
        }
    }
}
