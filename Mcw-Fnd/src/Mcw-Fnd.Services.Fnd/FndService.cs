using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Mcw_Fnd.Services.Fnd.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Mcw_Fnd.Services.Fnd
{
    public interface IFndService
    {
        Task<List<FndObject>> FindObjectsFromCity(string cityName);
        Task<List<FndObject>> FindObjectsFromCityWithGarden(string cityName);
    }

    public class FndService : IFndService
    {
        private readonly HttpClient client;

        public FndService(HttpClient client, IOptions<FndApiOptions> options)
        {
            this.client = client;

            var config = options.Value;

            var baseUrl = $"{config.BaseUrl}{config.SecretKey}/";

            client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<List<FndObject>> FindObjectsFromCity(string cityName)
        {
            var query = $"{cityName}";
            var result = await GetResponses(query);

            var objects = result.SelectMany(x => x.Objects).ToList();

            return objects;
        }

        public async Task<List<FndObject>> FindObjectsFromCityWithGarden(string cityName)
        {
            var query = $"{cityName}/Tuin";
            var result = await GetResponses(query);

            var objects = result.SelectMany(x => x.Objects).ToList();

            return objects;
        }

        private async Task<IList<FndResponse>> GetResponses(string queryString)
        {
            var page = 1;
            var availablePages = 1;

            var responses = new List<FndResponse>();

            do
            {
                var clientResponse = await client.GetAsync($"?type=koop&zo=/{queryString}/&page={page}&pagesize=25");
                var result = await clientResponse.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<FndResponse>(result);

                page = response.Paging.HuidigePagina + 1;
                availablePages = response.Paging.AantalPaginas;

                responses.Add(response);

            } while (page < availablePages);

            return responses;

        }
    }
}
