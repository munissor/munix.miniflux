namespace Munix.Miniflux
{
    public class GetFeedEntryRequest : GetEntryRequest
    {
        public GetFeedEntryRequest(int feedId, int entryId)
            : base(entryId)
        {
            this.FeedId = feedId;
        }

        public int FeedId { get; }
    }
}
