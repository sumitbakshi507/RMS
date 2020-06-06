using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.JobPostEngine.Domain.Models
{
    public class ExternalSystem
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Settings { get; set; }

        public bool IsInternal { get; set; }
    }
}
