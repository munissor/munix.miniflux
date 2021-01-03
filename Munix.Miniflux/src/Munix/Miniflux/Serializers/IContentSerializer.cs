namespace Munix.Miniflux.Serializers
{
    using System.Net.Http;

    public interface IContentSerializer
    {
        HttpContent Serialize(object value);
    }
}
