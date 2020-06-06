using RMS.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Commands
{
    public class JobPostCommand: Command
    {
        public int JobPostId { get; protected set; }

        public string Label { get; protected set; }

        public string Settings { get; protected set; }

        public bool IsInternal { get; protected set; }
    }
}
