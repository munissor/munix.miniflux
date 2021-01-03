namespace Munix.Miniflux.Serializers
{
    using System.Text.Json;

    internal class JsonContentDeserializer<T> : IContentDeserializer<T>
    {
        public T Deserialize(string value)
        {
            return JsonSerializer.Deserialize<T>(value);
        }
    }
}
