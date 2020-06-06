using RMS.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.InterviewEngine.Domain.Commands
{
    public class SelectCommand: Command
    {
        public int JobCandidateId { get; protected set; }

        public string Feedback { get; protected set; }
    }
}
