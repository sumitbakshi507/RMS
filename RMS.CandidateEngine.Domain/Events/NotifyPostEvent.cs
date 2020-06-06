using RMS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Domain.Events
{
    public class NotifyPostEvent : Event
    {
        public string Email { get; protected set; }

        public int JobPostId { get; protected set; }

        public int CandidateId { get; protected set; }
        public NotifyPostEvent(
            string email,
            int jobPostId,
            int candidateId)
        {
            Email = email;
            JobPostId = jobPostId;
            CandidateId = candidateId;
        }
    }
}
