namespace Munix.Miniflux
{
    using System.ComponentModel;

    public enum EntryStatus
    {
        None = 0,

        [Description("read")]
        Read = 1,
        [Description("unread")]
        Unread = 2,
        [Description("removed")]
        Removed = 3,
    }
}
