using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Models
{
    public class Job
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public int ManpowerRequestId { get; set; }
    }
}
