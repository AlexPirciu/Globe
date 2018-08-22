using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Globe.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int conferenceId);
        Task<StatisticsModel> GetStatistics();
        Task Add(ConferenceModel model);
    }
}
