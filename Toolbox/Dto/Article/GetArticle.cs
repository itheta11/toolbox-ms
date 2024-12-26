using System;

namespace Toolbox.Dto.Article;

public class GetArticle
{
    public Guid Id { get; set; }

    public string Userid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
