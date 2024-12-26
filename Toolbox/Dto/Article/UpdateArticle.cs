using System;

namespace Toolbox.Dto.Article;

public class UpdateArticle
{
    public string Title { get; set; } = null!;

    public string? Content { get; set; }
}
