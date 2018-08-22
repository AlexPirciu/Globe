using Globe.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Threading.Tasks;

namespace Globe.Controllers
{
    public class ProposalController : Controller
    {
        private readonly IConferenceService _conferenceService;
        private readonly IProposalService _proposalService;

        public ProposalController(IConferenceService conferenceService, IProposalService proposalService)
        {
            this._conferenceService = conferenceService;
            this._proposalService = proposalService;
        }

        public async Task<IActionResult> Index(int conferenceId)
        {
            var conference = await _conferenceService.GetById(conferenceId);
            ViewBag.Title = $"Proposals for conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = conferenceId;
            return View(await _proposalService.GetAll(conferenceId));
        }

        public IActionResult Add(int conferenceId)
        {
            ViewBag.Title = "Add proposal";
            return View(new ProposalModel { ConferenceId = conferenceId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel proposal)
        {
            if (ModelState.IsValid) await _proposalService.Add(proposal);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }

        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await _proposalService.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}