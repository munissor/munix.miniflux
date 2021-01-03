namespace Munix.Miniflux.Serializers
{
    public interface IContentDeserializer<T>
    {
        T Deserialize(string value);
    }
}
