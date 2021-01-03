namespace Munix.Miniflux.Serializers
{
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;

    internal class JsonContentSerializer : IContentSerializer
    {
        public JsonContentSerializer(bool ignoreNullValues = false)
        {
            this.IgnoreNullValues = ignoreNullValues;
        }

        public bool IgnoreNullValues { get; }

        public HttpContent Serialize(object parameters)
        {
            string json = JsonSerializer.Serialize(
                parameters,
                new JsonSerializerOptions() { IgnoreNullValues = this.IgnoreNullValues });
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}