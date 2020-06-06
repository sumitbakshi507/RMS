using RMS.RequestEngine.Data.Context;
using RMS.RequestEngine.Domain.Interfaces;
using RMS.RequestEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.RequestEngine.Data.Repository
{
    public class ManpowerRequestRepository : IManpowerRequestRepository
    {
        private RequestEngineDbContext _ctx;

        public ManpowerRequestRepository(RequestEngineDbContext ctx)
        {
            _ctx = ctx;
        }

        public int Add(ManpowerRequest manpowerRequest)
        {
            manpowerRequest.Status = 0;
            _ctx.Add(manpowerRequest);
            
            _ctx.SaveChanges();
            var id = manpowerRequest.Id;

            return id;
        }

        public IEnumerable<ManpowerRequest> GetAll()
        {
            return _ctx.ManpowerRequests.ToList();
        }
    }
}
