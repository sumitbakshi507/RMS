using RMS.Domain.Core.Bus;
using RMS.RequestEngine.Domain.Events;
using RMS.RequestEngine.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMS.RequestEngine.Domain.EventHandlers
{
    public class ManpowerRequestEventHandler : IEventHandler<ManpowerRequestCreatedEvent>
    {
        private readonly IManpowerRequestRepository _manpowerRequestRepository;

        public ManpowerRequestEventHandler(IManpowerRequestRepository manpowerRequestRepository)
        {
            _manpowerRequestRepository = manpowerRequestRepository;
        }

        public Task Handle(ManpowerRequestCreatedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
