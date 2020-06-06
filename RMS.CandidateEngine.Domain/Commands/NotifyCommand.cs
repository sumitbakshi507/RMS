using RMS.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Domain.Commands
{
    public class NotifyCommand : Command
    {
        public string Email { get; protected set; }

        public int JobPostId { get; protected set; }

        public int CandidateId { get; protected set; }
    }
}
