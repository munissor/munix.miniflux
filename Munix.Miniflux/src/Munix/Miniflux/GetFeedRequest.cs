namespace Munix.Miniflux
{
    public class GetFeedRequest
    {
        public GetFeedRequest(int feedId)
        {
            this.FeedId = feedId;
        }

        public int FeedId { get; }
    }
}
