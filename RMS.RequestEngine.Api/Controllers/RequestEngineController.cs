using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RMS.RequestEngine.Application.Interfaces;
using RMS.RequestEngine.Application.Models;

namespace RMS.RequestEngine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestEngineController : ControllerBase
    {
        private readonly ILogger<RequestEngineController> _logger;

        private readonly IManpowerRequestService _manpowerRequestService;

        public RequestEngineController(IManpowerRequestService manpowerRequestService,
            ILogger<RequestEngineController> logger)
        {
            _manpowerRequestService = manpowerRequestService;
            _logger = logger;
            _logger.LogInformation("Initialized");
        }

        // GET api/requests
        [HttpGet]
        [Route("Get")]
        public ActionResult<IEnumerable<ManpowerRequestVm>> Get()
        {
            return Ok(_manpowerRequestService.GetAll());
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] ManpowerRequestVm newRequest)
        {
            _manpowerRequestService.CreateRequest(newRequest);
            return Ok(newRequest);
        }
    }
}
