namespace Munix.Miniflux
{
    using System.Text.Json.Serialization;

    public class CreateUserRequest
    {
        public CreateUserRequest(string username, string password, bool isAdmin)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new System.ArgumentException($"'{nameof(username)}' cannot be null or whitespace", nameof(username));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new System.ArgumentException($"'{nameof(password)}' cannot be null or whitespace", nameof(password));
            }

            this.Username = username;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }

        [JsonPropertyName("username")]
        public string Username { get; }

        [JsonPropertyName("password")]
        public string Password { get; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; }
    }
}
