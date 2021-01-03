namespace Munix.Miniflux
{
    public class GetEntryRequest
    {
        public GetEntryRequest(long entryId)
        {
            this.EntryId = entryId;
        }

        public long EntryId { get; }
    }
}
