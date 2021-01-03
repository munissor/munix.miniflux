namespace Munix.Miniflux
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json.Serialization;

    public class EntryList
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819", Justification = "DTO")]
        [JsonPropertyName("entries")]
        public Entry[] Entries { get; set; }
    }
}
