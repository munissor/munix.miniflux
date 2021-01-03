namespace Munix.Miniflux
{
    using System.Text.Json.Serialization;

    public class IconReference
    {
        [JsonPropertyName("feed_id")]
        public int FeedId { get; set; }

        [JsonPropertyName("icon_id")]
        public int IconId { get; set; }
    }
}
