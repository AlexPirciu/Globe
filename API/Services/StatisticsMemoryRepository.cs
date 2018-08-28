using Shared.Models;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class StatisticsMemoryRepository : IStatisticsService
    {
        private readonly IConferenceService _conferenceService;

        public StatisticsMemoryRepository(IConferenceService conferenceService)
        {
            this._conferenceService = conferenceService;
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            var conferences = await _conferenceService.GetAll();
            return await Task.Run(() =>
             {
                 return new StatisticsModel
                 {
                     NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                     AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
                 };
             });
        }
    }
}
