using System;

namespace Toolbox.Dto.Cheatsheet;

public class CreateCheatsheet
{
    public string Userid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Content { get; set; }
}
