namespace Munix.Miniflux
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json.Serialization;

    public class DiscoverSubscriptionsRequest
    {
        public DiscoverSubscriptionsRequest(Uri url)
        {
            this.Uri = url ?? throw new ArgumentNullException(nameof(url));
        }

        [JsonIgnore]
        public Uri Uri { get; private set; }

        [SuppressMessage("Microsoft.Design", "CA1056", Justification = "DTO")]
        [JsonPropertyName("url")]
        public string Url
        {
            get => this.Uri.ToString();
        }
    }
}
