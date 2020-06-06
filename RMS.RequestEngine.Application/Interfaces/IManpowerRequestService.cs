using RMS.RequestEngine.Application.Models;
using RMS.RequestEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.RequestEngine.Application.Interfaces
{
    public interface IManpowerRequestService
    {
        IEnumerable<ManpowerRequestVm> GetAll();
        void CreateRequest(ManpowerRequestVm manpowerRequestVm);
    }
}
