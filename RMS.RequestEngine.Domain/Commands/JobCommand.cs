using RMS.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.RequestEngine.Domain.Commands
{
    public class JobCommand : Command
    {
        public int FromManpowerRequestId { get; protected set; }
    }
}
