using System;

namespace Toolbox.Dto.JsonItem;

public class CreateJsonItem
{
    public string Userid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Value { get; set; } = null!;
}
