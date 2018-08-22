using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globe.Services
{
    public class ProposalMemoryService : IProposalService
    {
        private readonly List<ProposalModel> _proposals = new List<ProposalModel>();

        public ProposalMemoryService()
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
            return Task.Run(() => _proposals.AsEnumerable().Where(c => c.ConferenceId == conferenceId));
        }

        public Task Add(ProposalModel model)
        {
            model.Id = _proposals.Max(p => p.Id) + 1;
            _proposals.Add(model);
            return Task.CompletedTask;
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            return Task.Run(() =>
            {
                ProposalModel proposal = _proposals.FirstOrDefault(p => p.Id == proposalId);
                proposal.Approved = true;
                return proposal;
            });
        }
    }
}
