namespace Munix.Miniflux
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json.Serialization;

    public class Feed
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1056", Justification = "DTO")]
        [JsonPropertyName("site_url")]
        public string SiteUrl { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1056", Justification = "DTO")]
        [JsonPropertyName("feed_url")]
        public string FeedUrl { get; set; }

        [JsonPropertyName("rewrite_rules")]
        public string RewriteRules { get; set; }

        [JsonPropertyName("scraper_rules")]
        public string ScraperRules { get; set; }

        [JsonPropertyName("crawler")]
        public bool Crawler { get; set; }

        [JsonPropertyName("checked_at")]
        public DateTime CheckedAt { get; set; }

        [JsonPropertyName("next_check_at")]
        public DateTime NextCheckAt { get; set; }

        [JsonPropertyName("etag_header")]
        public string ETagHeader { get; set; }

        [JsonPropertyName("last_modified_header")]
        public string LastModifiedHeader { get; set; }

        [JsonPropertyName("parsing_error_message")]
        public string ParsingErrorMessage { get; set; }

        [JsonPropertyName("parsing_error_count")]
        public int ParsingErrorCount { get; set; }

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("disabled")]
        public bool Disabled { get; set; }

        [JsonPropertyName("ignore_http_cache")]
        public bool IgnoreHttpCache { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("icon")]
        public IconReference Icon { get; set; }
    }
}
