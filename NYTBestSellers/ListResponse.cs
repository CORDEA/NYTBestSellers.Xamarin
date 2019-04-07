using Newtonsoft.Json;

namespace NYTBestSellers
{
    [JsonObject(ItemRequired = Required.Always)]
    public class ListResponse
    {
        [JsonProperty("list_name")] public string Name { get; private set; }

        [JsonProperty("display_name")] public string DisplayName { get; private set; }

        [JsonProperty("bestsellers_date")] public string BestsellersDate { get; private set; }

        [JsonProperty("published_date")] public string PublishedDate { get; private set; }

        [JsonProperty("rank")] public int Rank { get; private set; }

        [JsonProperty("rank_last_week")] public int LastWeekRank { get; private set; }

        [JsonProperty("weeks_on_list")] public int WeeksOnList { get; private set; }

        [JsonProperty("asterisk")] public int Asterisk { get; private set; }

        [JsonProperty("dagger")] public int Dagger { get; private set; }

        [JsonProperty("amazon_product_url")] public string AmazonProductUrl { get; private set; }
    }
}