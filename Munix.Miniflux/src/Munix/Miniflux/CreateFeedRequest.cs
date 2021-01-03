namespace Munix.Miniflux
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json.Serialization;

    public class CreateFeedRequest
    {
        public CreateFeedRequest(Uri feedUrl, int categoryId)
        {
            this.FeedUri = feedUrl ?? throw new ArgumentNullException(nameof(feedUrl));
            this.CategoryId = categoryId;
        }

        [JsonIgnore]
        public Uri FeedUri { get; private set; }

        [SuppressMessage("Microsoft.Design", "CA1056", Justification = "DTO")]
        [JsonPropertyName("feed_url")]
        public string FeedUrl
        {
            get => this.FeedUri.ToString();
        }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("crawler")]
        public bool? Crawler { get; set; }

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }

        [JsonPropertyName("scraper_rules")]
        public string ScraperRules { get; set; }

        [JsonPropertyName("rewrite_rules")]
        public string RewriteRules { get; set; }
    }
}
