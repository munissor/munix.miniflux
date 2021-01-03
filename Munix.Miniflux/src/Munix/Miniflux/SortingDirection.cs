namespace Munix.Miniflux
{
    using System.ComponentModel;

    public enum SortingDirection
    {
        None = 0,
        [Description("asc")]
        Ascending = 1,
        [Description("desc")]
        Descending = 2,
    }
}
