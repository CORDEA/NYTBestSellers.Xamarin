using Newtonsoft.Json;

namespace NYTBestSellers
{
    [JsonObject(ItemRequired = Required.Always)]
    public class ListIsbnResponse
    {
        [JsonProperty("isbn10")] public string Isbn10 { get; private set; }

        [JsonProperty("isbn13")] public string Isbn13 { get; private set; }
    }
}