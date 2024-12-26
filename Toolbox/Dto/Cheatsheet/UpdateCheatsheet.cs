using System;

namespace Toolbox.Dto.Cheatsheet;

public class UpdateCheatsheet
{
    public string Title { get; set; } = null!;

    public string? Content { get; set; }
}
