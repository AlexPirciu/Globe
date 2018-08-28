using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ConferenceMemoryRepository : IConferenceService
    {
        private readonly List<ConferenceModel> _conferences = new List<ConferenceModel>();

        public ConferenceMemoryRepository()
        {
            _conferences.Add(new ConferenceModel
            {
                Id = 1,
                Name = "Ndc",
                Location = "Oslo",
                Start = new DateTime(2018, 08, 21),
                AttendeeTotal = 2132
            });

            _conferences.Add(new ConferenceModel
            {
                Id = 2,
                Name = "It/DevConnections",
                Location = "San Francisco",
                Start = new DateTime(2018, 10, 18),
                AttendeeTotal = 3210
            });
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => _conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetById(int conferenceId)
        {
            return Task.Run(() => _conferences.FirstOrDefault(c => c.Id == conferenceId));
        }

        public Task<ConferenceModel> Add(ConferenceModel model)
        {
            return Task.Run(() =>
            {
                model.Id = _conferences.Max(c => c.Id) + 1;
                _conferences.Add(model);
                return model;
            });
        }
    }
}
