using API.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProposalController : Controller
    {
        private readonly IProposalService _proposalService;

        public ProposalController(IProposalService proposalService)
        {
            this._proposalService = proposalService;
        }

        [HttpGet("{conferenceId}")]
        public async Task<IActionResult> GetAll(int conferenceId)
        {
            var proposals = await _proposalService.GetAll(conferenceId);

            if (!proposals.Any()) return new NoContentResult();
            return new ObjectResult(proposals);
        }

        [HttpGet("{proposalId}", Name = "GetById")]
        public async Task<IActionResult> GetById(int proposalId)
        {
            var proposal = await _proposalService.GetById(proposalId);

            return new ObjectResult(proposal);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProposalModel proposal, int conferenceId)
        {
            var proposalAdded = await _proposalService.Add(proposal);
            return CreatedAtRoute("GetById", new { proposalId = proposalAdded.Id }, proposalAdded);
        }

        [HttpPut("{proposalId}")]
        public async Task<IActionResult> Approve(int proposalId)
        {
            try
            {
                return new ObjectResult(await _proposalService.Approve(proposalId));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}