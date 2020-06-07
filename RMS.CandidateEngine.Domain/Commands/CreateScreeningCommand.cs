using RMS.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.CandidateEngine.Domain.Commands
{
    public class CreateScreeningCommand : Command
    {
        public int JobCandidateId { get; protected set; }

        public CreateScreeningCommand(int jobCandidateId) {
            JobCandidateId = jobCandidateId;
        }
    }
}
