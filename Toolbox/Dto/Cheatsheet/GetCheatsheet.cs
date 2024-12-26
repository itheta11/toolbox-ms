using System;

namespace Toolbox.Dto.Cheatsheet;

public class GetCheatsheet
{
    public Guid Id { get; set; }

    public string Userid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
