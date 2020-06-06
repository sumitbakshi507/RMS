using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Models
{
    public class JobPost
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? PostDate { get; set; }

        public int ExternalSystemId { get; set; }
    }
}
