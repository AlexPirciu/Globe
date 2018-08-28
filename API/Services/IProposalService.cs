using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IProposalService
    {
        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);
        Task<ProposalModel> GetById(int proposalId);
        Task<ProposalModel> Approve(int proposalId);
        Task<ProposalModel> Add(ProposalModel model);
    }
}
