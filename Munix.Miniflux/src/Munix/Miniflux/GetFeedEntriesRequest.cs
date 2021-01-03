namespace Munix.Miniflux
{
    public class GetFeedEntriesRequest : GetEntriesRequest
    {
        public GetFeedEntriesRequest(int feedId)
        {
            this.FeedId = feedId;
        }

        public int FeedId { get; private set; }
    }
}
