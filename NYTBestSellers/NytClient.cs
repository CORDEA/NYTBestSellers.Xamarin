using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NYTBestSellers
{
    internal class NytClient
    {
        private const string BaseUrl = "https://api.nytimes.com/svc/books/v3/";
        private const string GetListsPath = "lists.json";
        private const string GetListNamesPath = "lists/names.json";

        private readonly HttpClient _client = new HttpClient();

        private static string BuildUrl(string path, Dictionary<string, string> query)
        {
            return query.Aggregate($"{BaseUrl}{path}?api-key={NytCredentials.ApiToken}",
                (current, q) => $"{current}&{q.Key}={q.Value}");
        }

        public async Task<ListNamesResponse> GetListNames()
        {
            var result = await _client.GetAsync(BuildUrl(GetListNamesPath, new Dictionary<string, string>()));
            return JsonConvert.DeserializeObject<ListNamesResponse>(await result.Content.ReadAsStringAsync());
        }

        public async Task<ListsResponse> GetLists(string list)
        {
            var query = new Dictionary<string, string> {{"list", list}};
            var result = await _client.GetAsync(BuildUrl(GetListsPath, query));
            return JsonConvert.DeserializeObject<ListsResponse>(await result.Content.ReadAsStringAsync());
        }
    }
}