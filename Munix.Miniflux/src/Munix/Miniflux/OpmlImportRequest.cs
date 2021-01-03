namespace Munix.Miniflux
{
    public class OpmlImportRequest
    {
        public OpmlImportRequest(string content)
        {
            this.Content = content;
        }

        public string Content { get; }
    }
}
