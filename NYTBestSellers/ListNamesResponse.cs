using Newtonsoft.Json;

namespace NYTBestSellers
{
    [JsonObject]
    public class ListNamesResponse
    {
        [JsonProperty("results")] public ListNameResponse[] Results { get; private set; }
    }
}