using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RMS.CandidateEngine.Application.Contracts;
using RMS.CandidateEngine.Application.Models;

namespace RMS.CandidateEngine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;

        private readonly ICandidateService _candidateService;

        public CandidateController(
            ICandidateService candidateService,
            ILogger<CandidateController> logger)
        {
            _candidateService = candidateService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<JobCandidateVM> GetByJobPost(int jobPostId)
        {
            return _candidateService.GetByJobPost(jobPostId);
        }

        [HttpPost]
        [Route("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(
            [FromForm]PublicPostVM request)
        {
            return Ok(await _candidateService.AddRequest(request));
        }
    }
}
