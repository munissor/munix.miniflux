namespace Munix.Miniflux.Serializers
{
    using System.Net.Http;
    using System.Text;

    internal class TextContentSerializer : IContentSerializer
    {
        public TextContentSerializer(string mimeType)
        {
            if (string.IsNullOrWhiteSpace(mimeType))
            {
                throw new System.ArgumentException($"'{nameof(mimeType)}' cannot be null or whitespace", nameof(mimeType));
            }

            this.MimeType = mimeType;
        }

        public string MimeType { get; }

        public HttpContent Serialize(object parameters)
        {
            string text = (string)parameters.ToString();
            return new StringContent(text, Encoding.UTF8, this.MimeType);
        }
    }
}
