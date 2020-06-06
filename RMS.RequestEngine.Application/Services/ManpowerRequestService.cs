using RMS.Domain.Core.Bus;
using RMS.RequestEngine.Application.Interfaces;
using RMS.RequestEngine.Application.Models;
using RMS.RequestEngine.Domain.Commands;
using RMS.RequestEngine.Domain.Interfaces;
using RMS.RequestEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.RequestEngine.Application.Services
{
    public class ManpowerRequestService: IManpowerRequestService
    {
        private readonly IEventBus _bus;
        private readonly IManpowerRequestRepository _manpowerRequestRepository;

        public ManpowerRequestService(IEventBus bus,
            IManpowerRequestRepository manpowerRequestRepository)
        {
            _bus = bus;
            _manpowerRequestRepository = manpowerRequestRepository;
        }

        public IEnumerable<ManpowerRequestVm> GetAll()
        {
            var vm = new List<ManpowerRequestVm>();
            _manpowerRequestRepository.GetAll().ToList().ForEach(i =>
            {
                vm.Add(new ManpowerRequestVm() { 
                    Description = i.Description,
                    HiringManagerId = i.HiringManagerId,
                    Id = i.Id,
                    Level = i.Level,
                    Title = i.Title
                });
            });
            return vm;
        }

        public void CreateRequest(ManpowerRequestVm manpowerRequestVm) {
            var manpowerRequest = new ManpowerRequest() {
                Description = manpowerRequestVm.Description,
                HiringManagerId = manpowerRequestVm.HiringManagerId,
                Level = manpowerRequestVm.Level,
                Status = 0,
                Title = manpowerRequestVm.Title
            };
            var id = _manpowerRequestRepository.Add(manpowerRequest);

            this.CreateJob(id);
        }

        private void CreateJob(int manpowerRequestId)
        {
            var createJobCommand = new CreateJobCommand(manpowerRequestId);

            _bus.SendCommand(createJobCommand);
        }
    }
}
