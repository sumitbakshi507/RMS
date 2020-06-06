using System;

namespace RMS.RequestEngine.Domain.Models
{
    public class ManpowerRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string HiringManagerId { get; set; }

        public string Level { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }
    }
}
