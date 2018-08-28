using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int conferenceId);
        Task<ConferenceModel> Add(ConferenceModel model);
    }
}
