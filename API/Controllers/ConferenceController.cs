using API.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceService _conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            this._conferenceService = conferenceService;
        }

        public async Task<IActionResult> GetAll()
        {
            var conferences = await _conferenceService.GetAll();
            if (!conferences.Any())
            {
                return new NoContentResult();
            }
            return new ObjectResult(conferences);
        }

        [HttpGet("{conferenceId}")]
        public async Task<IActionResult> GetById(int conferenceId)
        {
            var conference = await _conferenceService.GetById(conferenceId);
            return new ObjectResult(conference);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ConferenceModel conference)
        {
            var addedConference = await _conferenceService.Add(conference);
            return CreatedAtRoute("GetById", new { id = addedConference.Id }, addedConference);
        }
    }
}