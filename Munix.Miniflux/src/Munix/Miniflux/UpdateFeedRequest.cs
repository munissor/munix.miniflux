namespace Munix.Miniflux
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json.Serialization;

    public class UpdateFeedRequest
    {
        public UpdateFeedRequest(int feedId)
        {
            this.FeedId = feedId;
        }

        [JsonIgnore]
        public int FeedId { get; private set; }

        [SuppressMessage("Microsoft.Design", "CA1056", Justification = "DTO")]
        [JsonPropertyName("feed_url")]
        public string FeedUrl { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1056", Justification = "DTO")]
        [JsonPropertyName("site_url")]
        public string SiteUrl { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("category_id")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("scraper_rules")]
        public string ScraperRules { get; set; }

        [JsonPropertyName("rewrite_rules")]
        public string RewriteRules { get; set; }

        [JsonPropertyName("crawler")]
        public bool? Crawler { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }
    }
}
