using Newtonsoft.Json;

namespace NYTBestSellers
{
    [JsonObject]
    public class ListsResponse
    {
        [JsonProperty("results")] public ListResponse[] Results { get; private set; }
    }
}