using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.RequestEngine.Domain.Commands
{
    public class CreateJobCommand: JobCommand
    {
        public CreateJobCommand(
            int fromManpowerRequestId)
        {
            FromManpowerRequestId = fromManpowerRequestId;
        }
    }
}
