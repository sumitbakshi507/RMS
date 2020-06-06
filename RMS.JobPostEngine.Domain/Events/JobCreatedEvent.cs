using RMS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Events
{
    public class JobCreatedEvent : Event
    {
        public int FromManpowerRequestId { get; private set; }

        public JobCreatedEvent(int fromManpowerRequestId)
        {
            FromManpowerRequestId = fromManpowerRequestId;
        }
    }
}
