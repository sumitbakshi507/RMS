using RMS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Domain.Events
{
    public class CreateScreeningEvent : Event
    {
        public CreateScreeningEvent(int jobCandidateId)
        {
            JobCandidateId = jobCandidateId;
        }

        public int JobCandidateId { get; protected set; }
    }
}
