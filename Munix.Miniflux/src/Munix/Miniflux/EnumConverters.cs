namespace Munix.Miniflux
{
    internal static class EnumConverters
    {
        internal static readonly EnumConverter<EntryStatus> EntryStatusConverter
            = new EnumConverter<EntryStatus>();

        internal static readonly EnumConverter<SortingOption> SortingOptionConverter
            = new EnumConverter<SortingOption>();

        internal static readonly EnumConverter<SortingDirection> SortingDirectionConverter
            = new EnumConverter<SortingDirection>();
    }
}
