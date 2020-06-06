using RMS.RequestEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.RequestEngine.Domain.Interfaces
{
    public interface IManpowerRequestRepository
    {
        IEnumerable<ManpowerRequest> GetAll();

        int Add(ManpowerRequest manpowerRequest);
    }
}
