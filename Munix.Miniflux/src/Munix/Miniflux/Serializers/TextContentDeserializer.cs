namespace Munix.Miniflux.Serializers
{
    internal class TextContentDeserializer : IContentDeserializer<string>
    {
        public string Deserialize(string value)
        {
            return value;
        }
    }
}
