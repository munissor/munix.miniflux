namespace Munix.Miniflux
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json.Serialization;

    public class DiscoveredFeed
    {
        [SuppressMessage("Microsoft.Design", "CA1056", Justification = "DTO")]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
