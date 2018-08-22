using Globe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Globe.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly IConferenceService _conferenceService;

        public StatisticsViewComponent(IConferenceService conferenceService)
        {
            this._conferenceService = conferenceService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string statsCaption)
        {
            ViewBag.Caption = statsCaption;
            return View(await _conferenceService.GetStatistics());
        }
    }
}
