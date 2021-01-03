namespace Munix.Miniflux
{
    public class GetEntriesRequest
    {
        public EntryStatus EntryStatus { get; set; }

        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public SortingOption SortingOption { get; set; }

        public SortingDirection SortingDirection { get; set; }

        public long? Before { get; set; }

        public long? After { get; set; }

        public long? BeforeEntryId { get; set; }

        public long? AfterEntryId { get; set; }

        public bool? Starred { get; set; }

        public string Search { get; set; }

        public int? CategoryId { get; set; }
    }
}
