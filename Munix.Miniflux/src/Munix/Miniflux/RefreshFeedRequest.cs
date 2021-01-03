namespace Munix.Miniflux
{
    public class RefreshFeedRequest
    {
        public RefreshFeedRequest(int feedId)
        {
            this.FeedId = feedId;
        }

        public int FeedId { get; private set; }
    }
}
