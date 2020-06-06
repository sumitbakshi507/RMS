using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RMS.JobPostEngine.Application.Contracts;
using RMS.JobPostEngine.Domain.Models;

namespace RMS.JobPostEngine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly ILogger<JobController> _logger;
        public JobController(
            IJobService jobService,
            ILogger<JobController> logger)
        {
            _jobService = jobService;
            _logger = logger;
            _logger.LogInformation("Initiated");
        }

        // GET api/jobs
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            return Ok(_jobService.GetJobs());
        }
    }
}
