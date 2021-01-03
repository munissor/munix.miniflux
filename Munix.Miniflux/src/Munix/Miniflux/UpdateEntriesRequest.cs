namespace Munix.Miniflux
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json.Serialization;

    public class UpdateEntriesRequest
    {
        public UpdateEntriesRequest(long[] entryIds, EntryStatus status)
        {
            this.EntryIds = entryIds ?? throw new System.ArgumentNullException(nameof(entryIds));
            this.Status = status;
        }

        [SuppressMessage("Microsoft.Performance", "CA1819", Justification = "DTO")]
        [JsonPropertyName("entry_ids")]
        public long[] EntryIds { get; private set; }

        [JsonIgnore]
        public EntryStatus Status { get; private set; }

        [JsonPropertyName("status")]
        public string StatusText
        {
            get => EnumConverters.EntryStatusConverter.ToString(this.Status);
        }
    }
}
