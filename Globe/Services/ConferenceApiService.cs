using Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Globe.Services
{
    public class ConferenceApiService : IConferenceService
    {
        private readonly HttpClient _client;

        public ConferenceApiService(IHttpClientFactory httpClientFactory)
        {
            this._client = httpClientFactory.CreateClient("GlobeApi");
        }

        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            var result = new List<ConferenceModel>();
            var response = await _client.GetAsync("/v1/conference");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<ConferenceModel>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }

        public async Task<ConferenceModel> GetById(int conferenceId)
        {
            var result = new ConferenceModel();
            var response = await _client.GetAsync($"/v1/conference/{conferenceId}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<ConferenceModel>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            var result = new StatisticsModel();
            var response = await _client.GetAsync("/v1/statistics");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<StatisticsModel>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }

        public async Task Add(ConferenceModel model)
        {
            await _client.PostAsJsonAsync("/v1/conference", model);
        }
    }
}
