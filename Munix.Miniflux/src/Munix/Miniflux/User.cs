namespace Munix.Miniflux
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json.Serialization;

    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("theme")]
        public string Theme { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonIgnore]
        public SortingDirection SortingDirection { get; set; }

        [JsonPropertyName("entry_sorting_direction")]
        public string SortingDirectionText
        {
            get => EnumConverters.SortingDirectionConverter.ToString(this.SortingDirection);
            set => this.SortingDirection = EnumConverters.SortingDirectionConverter.ToEnum(value);
        }

        [JsonPropertyName("last_login_at")]
        public DateTime LastLoginAt { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227", Justification = "DTO")]
        [JsonPropertyName("extra")]
        public IDictionary<string, string> Extra { get; set; }
    }
}
