using RMS.JobPostEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Interfaces
{
    public interface IExternalSystemRepository
    {
        IEnumerable<ExternalSystem> GetSystems();
    }
}
