namespace Munix.Miniflux
{
    using System.Text.Json.Serialization;

    public class ErrorResponse
    {
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
    }
}
