namespace NewsArticles.Persistence.Data;

internal static class Seeders
{
    private readonly static Admin Admin = new()
    {
        Id = Guid.Parse("61441ae2-2850-4bc6-6134-08dc9cc80f95"),
        FirstName = "NewsArticles Website Admin",
        LastName = "MoMakkawi",
        Email = "MoMakkawi@hotmail.com",
        UserName = "MoMakkawi",
        PhoneNumber = "1234567890"
    };
    private readonly static List<Author> Authors = [
            new()
            {
                Id = Guid.Parse("EE36E774-49FC-4904-8C62-AD8BF9695B45"),
                FirstName = "Author",
                LastName = "1",
                Email = "Author1@hotmail.com",
                UserName = "Author1",
                PhoneNumber = "1206656645",
                NewsArticles = []
            },
            new()
            {
                Id = Guid.Parse("F6E1E975-8752-4C18-AD79-BAF5B37CEC07"),
                FirstName = "Author",
                LastName = "2",
                Email = "Author2@hotmail.com",
                UserName = "Author2",
                PhoneNumber = "955959",
                NewsArticles = []
            },
            new()
            {
                Id = Guid.Parse("D07B1DC6-CB13-42F8-BCF9-6C68275A599E"),
                FirstName = "Author",
                LastName = "3",
                Email = "Author3@hotmail.com",
                UserName = "Author3",
                PhoneNumber = "12388890",
                NewsArticles = []
            }
            ];
    private readonly static List<Commenter> Commenters = [
        new()
            {
                Id = Guid.Parse("5208D585-FFAA-47F4-B25D-F9D577EC4085"),
                FirstName = "Commenter",
                LastName = "1",
                Email = "Commenter1@hotmail.com",
                UserName = "Commenter1",
                PhoneNumber = "12062346645"
            },
            new()
            {
                Id = Guid.Parse("FEEAB2D5-0824-4CBB-BCA4-09979D7CD097"),
                FirstName = "Commenter",
                LastName = "2",
                Email = "Commenter2@hotmail.com",
                UserName = "Commenter2",
                PhoneNumber = "952345959"
            },
            new()
            {
                Id = Guid.Parse("B7DE5136-9646-4180-B750-4C5F672FD392"),
                FirstName = "Commenter",
                LastName = "3",
                Email = "Commenter3@hotmail.com",
                UserName = "Commenter3",
                PhoneNumber = "494985498498"
            }
        ];
    private readonly static List<NewsArticle> NewsArticles = [
            new NewsArticle()
            {
                Id = Guid.Parse("182c8565-d6f8-4600-1e46-08dc978c994e"),
                Author = Authors.First(),
                AuthorId = Authors.First().Id,
                Content = "First Article Content",
                Title = "First Article Title",
                PublishedDate = DateTime.Now,
                ViewsCount = 1,
                ImagesNames = []
            },
            new NewsArticle()
            {
                Id = Guid.Parse("0af8ba4c-6ed7-49a3-1e47-08dc978c994e"),
                Author = Authors.Last(),
                AuthorId = Authors.Last().Id,
                Content = "Second Article Content",
                Title = "Second Article Title",
                PublishedDate = DateTime.Now.AddDays(12),
                ViewsCount = 1,
                ImagesNames = []
            },
            new NewsArticle()
            {
                Id = Guid.Parse("8f8b53ab-9381-4d25-1e48-08dc978c994e"),
                Author = Authors.Last(),
                AuthorId = Authors.Last().Id,
                Content = "Third Article Content",
                Title = "Third Article Title",
                PublishedDate = DateTime.Now.AddMonths(1),
                ViewsCount = 1,
                ImagesNames = ["Pic1.png"]
            }
            ];

    public static void SeedData(NewsArticleDBContext newsArticleDBContext)
    {
        if (!newsArticleDBContext
            .Set<Admin>()
            .Any(admin => admin.Id == Admin.Id))
            newsArticleDBContext.Add(Admin);

        // seed authors 
        var unseededAuthors = Authors
            .Where(author => !newsArticleDBContext.Authors.Any(savedAuthor => savedAuthor.Id == author.Id));

        newsArticleDBContext.AddRange(unseededAuthors);

        // seed commenters 
        var unseededCommenter = Commenters
            .Where(commenter => !newsArticleDBContext.Commenters.Any(savedCommenter => savedCommenter.Id == commenter.Id));

        newsArticleDBContext.AddRange(unseededCommenter);

        // seed news articles
        var unseededNewsArticles = NewsArticles
            .Where(newsArticle => !newsArticleDBContext.NewsArticles.Any(savedNewsArticle => savedNewsArticle.Id == newsArticle.Id));

        newsArticleDBContext.AddRange(unseededNewsArticles);

        newsArticleDBContext.SaveChanges();
    }
}
