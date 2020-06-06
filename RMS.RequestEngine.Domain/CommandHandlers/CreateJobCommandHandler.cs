using MediatR;
using RMS.Domain.Core.Bus;
using RMS.RequestEngine.Domain.Commands;
using RMS.RequestEngine.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RMS.RequestEngine.Domain.CommandHandlers
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, bool>
    {
        private readonly IEventBus _bus;

        public CreateJobCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _bus.Publish(new JobCreatedEvent(request.FromManpowerRequestId));

            return Task.FromResult(true);
        }
    }
}
