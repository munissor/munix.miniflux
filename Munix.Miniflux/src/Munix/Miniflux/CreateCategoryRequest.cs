namespace Munix.Miniflux
{
    using System.Text.Json.Serialization;

    public class CreateCategoryRequest
    {
        public CreateCategoryRequest(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new System.ArgumentException(
                    $"'{nameof(title)}' cannot be null or whitespace",
                    nameof(title));
            }

            this.Title = title;
        }

        [JsonPropertyName("title")]
        public string Title { get; }
    }
}
