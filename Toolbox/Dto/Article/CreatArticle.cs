using System;

namespace Toolbox.Dto.Article;

public class CreatArticle
{

    public string Userid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

}
