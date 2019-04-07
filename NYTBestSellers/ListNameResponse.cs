using Newtonsoft.Json;

namespace NYTBestSellers
{
    [JsonObject(ItemRequired = Required.Always)]
    public class ListNameResponse
    {
        [JsonProperty("list_name")] public string Name { get; private set; }

        [JsonProperty("display_name")] public string DisplayName { get; private set; }

        [JsonProperty("list_name_encoded")] public string EncodedName { get; private set; }

        [JsonProperty("oldest_published_date")]
        public string OldestPublishedDate { get; private set; }

        [JsonProperty("newest_published_date")]
        public string NewestPublishedDate { get; private set; }

        [JsonProperty("updated")] public string Updated { get; private set; }
    }
}