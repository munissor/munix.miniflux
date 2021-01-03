namespace Munix.Miniflux
{
    public class ToggleEntryBookmarkRequest
    {
        public ToggleEntryBookmarkRequest(long entryId)
        {
            this.EntryId = entryId;
        }

        public long EntryId { get; private set; }
    }
}
