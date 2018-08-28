using Shared.Models;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IStatisticsService
    {
        Task<StatisticsModel> GetStatistics();
    }
}
