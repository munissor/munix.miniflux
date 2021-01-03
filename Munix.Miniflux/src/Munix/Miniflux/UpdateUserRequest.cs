namespace Munix.Miniflux
{
    using System.Text.Json.Serialization;

    public class UpdateUserRequest
    {
        public UpdateUserRequest(int userId)
        {
            this.UserId = userId;
        }

        [JsonIgnore]
        public int UserId { get; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("is_admin")]
        public bool? IsAdmin { get; set; }

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
    }
}
