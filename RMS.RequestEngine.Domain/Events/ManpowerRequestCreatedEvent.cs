using RMS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.RequestEngine.Domain.Events
{
    public class ManpowerRequestCreatedEvent : Event
    {
        public string Title { get; set; }

        public string HiringManagerId { get; set; }

        public string Level { get; set; }

        public string Description { get; set; }

        public ManpowerRequestCreatedEvent(
            string title,
            string hiringManagerId,
            string level,
            string description
            )
        {
            Title = title;
            HiringManagerId = HiringManagerId;
            Level = level;
            Description = description;
        }
    }
}
