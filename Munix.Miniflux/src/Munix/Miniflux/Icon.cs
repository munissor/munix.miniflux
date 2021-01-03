namespace Munix.Miniflux
{
    using System.Text.Json.Serialization;

    public class Icon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; }
    }
}
