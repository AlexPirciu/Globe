using API.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this._statisticsService = statisticsService;
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            return await _statisticsService.GetStatistics();
        }
    }
}