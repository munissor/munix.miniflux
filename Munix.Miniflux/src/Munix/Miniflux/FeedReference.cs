namespace Munix.Miniflux
{
    using System.Text.Json.Serialization;

    public class FeedReference
    {
        [JsonPropertyName("feed_id")]
        public int FeedId { get; set; }
    }
}
