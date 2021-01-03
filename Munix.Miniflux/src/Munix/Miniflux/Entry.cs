namespace Munix.Miniflux
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json.Serialization;

    public class Entry
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("feed_id")]
        public int FeedId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1056", Justification = "DTO")]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1056", Justification = "DTO")]
        [JsonPropertyName("comments_url")]
        public string CommentsUrl { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("starred")]
        public bool Starred { get; set; }

        [JsonPropertyName("feed")]
        public Feed Feed { get; set; }
    }
}
