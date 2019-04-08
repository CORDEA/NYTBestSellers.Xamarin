using Newtonsoft.Json;

namespace NYTBestSellers
{
    [JsonObject(ItemRequired = Required.Always)]
    public class ListReviewResponse
    {
        [JsonProperty("book_review_link")] public string BookReviewLink { get; private set; }

        [JsonProperty("first_chapter_link")] public string FirstChapterLink { get; private set; }

        [JsonProperty("sunday_review_link")] public string SundayReviewLink { get; private set; }

        [JsonProperty("article_chapter_link")] public string ArticleChapterLink { get; private set; }
    }
}