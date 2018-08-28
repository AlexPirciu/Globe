using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProposalMemoryRepository : IProposalService
    {
        private readonly List<ProposalModel> _proposals = new List<ProposalModel>();

        public ProposalMemoryRepository()
        {
            _proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "John Roth",
                Title = "Understanding ASP.NET Core"
            });

            _proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 1,
                Speaker = "Sebastian Dorney",
                Title = "Building a startup"
            });

            _proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Dave Reynolds",
                Title = "ASP.NET Core Security"
            });
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => _proposals.AsEnumerable().Where(p => p.ConferenceId == conferenceId));
        }

        public Task<ProposalModel> GetById(int proposalId)
        {
            return Task.Run(() => _proposals.FirstOrDefault(p => p.Id == proposalId));
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            var proposal = _proposals.FirstOrDefault(p => p.Id == proposalId);
            proposal.Approved = true;
            return Task.Run(() =>
            {
                return proposal;
            });
        }

        public Task<ProposalModel> Add(ProposalModel model)
        {
            return Task.Run(() =>
            {
                model.Id = _proposals.Max(c => c.Id) + 1;
                _proposals.Add(model);
                return model;
            });
        }
    }
}
