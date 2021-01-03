namespace Munix.Miniflux
{
    using System.ComponentModel;

    public enum SortingOption
    {
        None = 0,
        [Description("id")]
        Id = 1,
        [Description("status")]
        Status = 2,
        [Description("published_at")]
        PublishedAt = 3,
        [Description("category_title")]
        CategoryTitle,
        [Description("category_id")]
        CategoryId,
    }
}
