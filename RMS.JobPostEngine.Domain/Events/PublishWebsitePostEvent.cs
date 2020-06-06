using RMS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Events
{
    public class PublishWebsitePostEvent: Event
    {
        public int JobPostId { get; protected set; }
        
        public string Label { get; protected set; }

        public string Settings { get; protected set; }

        public bool IsInternal { get; protected set; }

        public PublishWebsitePostEvent(
            int jobPostId,
            string label,
            string settings,
            bool isInternal)
        {
            JobPostId = jobPostId;
            Settings = settings;
            Label = label;
            IsInternal = isInternal;
        }
    }
}
