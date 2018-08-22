using Globe.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Threading.Tasks;

namespace Globe.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceService _conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            this._conferenceService = conferenceService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conferences Overview";
            return View(await _conferenceService.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Add conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel conference)
        {
            if (ModelState.IsValid) await _conferenceService.Add(conference);
            return RedirectToAction("Index");
        }
    }
}