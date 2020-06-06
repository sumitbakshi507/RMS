using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.RequestEngine.Application.Models
{
    public class ManpowerRequestVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string HiringManagerId { get; set; }

        public string Level { get; set; }

        public string Description { get; set; }
    }
}
