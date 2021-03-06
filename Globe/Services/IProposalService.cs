﻿using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Globe.Services
{
    public interface IProposalService
    {
        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);
        Task Add(ProposalModel model);
        Task<ProposalModel> Approve(int proposalId);
    }
}
