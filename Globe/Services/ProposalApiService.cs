using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Globe.Services
{
    public class ProposalApiService : IProposalService
    {
        private readonly HttpClient _client;

        public ProposalApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("GlobeApi");
        }

        public async Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            var result = new List<ProposalModel>();
            var response = await _client.GetAsync($"/v1/proposal/{conferenceId}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<ProposalModel>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }

        public async Task Add(ProposalModel model)
        {
            await _client.PostAsJsonAsync("/v1/proposal", model);
        }

        public async Task<ProposalModel> Approve(int proposalId)
        {
            var response = await _client.PutAsync($"/v1/proposal/{proposalId}", null);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<ProposalModel>();
            throw new ArgumentException($"Error retrieving proposal {proposalId}" + $"Response: {response.ReasonPhrase}");
        }
    }
}
