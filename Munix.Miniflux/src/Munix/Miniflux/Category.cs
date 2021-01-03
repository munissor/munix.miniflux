namespace Munix.Miniflux
{
    using System.Text.Json.Serialization;

    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
