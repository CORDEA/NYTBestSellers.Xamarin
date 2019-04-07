using Newtonsoft.Json;

namespace NYTBestSellers
{
    [JsonObject(ItemRequired = Required.Always)]
    public class ListBookDetailsResponse
    {
        [JsonProperty("title")] public string Title { get; private set; }

        [JsonProperty("description")] public string Description { get; private set; }

        [JsonProperty("contributor")] public string Contributor { get; private set; }

        [JsonProperty("author")] public string Author { get; private set; }

        [JsonProperty("contributor_note")] public string ContributorNote { get; private set; }

        [JsonProperty("price")] public int Price { get; private set; }

        [JsonProperty("age_group")] public string AgeGroup { get; private set; }

        [JsonProperty("publisher")] public string Publisher { get; private set; }

        [JsonProperty("primary_isbn13")] public string PrimaryIsbn13 { get; private set; }

        [JsonProperty("primary_isbn10")] public string PrimaryIsbn10 { get; private set; }
    }
}