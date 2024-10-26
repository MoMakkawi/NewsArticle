namespace NewsArticles.Persistence.Constants;

public static class Roles
{
    public static readonly Guid ADMIN_ID = Guid.Parse("94633DD9-1E27-4391-830E-B25125962757");
    public const string ADMIN = "ADMIN";

    public static readonly Guid AUTHOR_ID = Guid.Parse("B551126B-B201-495A-B1BD-413363809926");
    public const string AUTHOR = "AUTHOR";

    public static readonly Guid COMMENTER_ID = Guid.Parse("B1094FA5-9179-400B-8B88-6D5F801A4EF6");
    public const string COMMENTER = "COMMENTER";
}