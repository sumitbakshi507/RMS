using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Commands
{
    public class PublishWebsitePostCommand: JobPostCommand
    {
        public PublishWebsitePostCommand(
            int jobPostId,
            string label,
            string settings,
            bool isInternal)
        {
            JobPostId = jobPostId;
            Label = label;
            Settings = settings;
            IsInternal = isInternal;
        }
    }
}
