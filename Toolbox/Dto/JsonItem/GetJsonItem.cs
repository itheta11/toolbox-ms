using System;

namespace Toolbox.Dto.JsonItem;

public class GetJsonItem
{
    public Guid Id { get; set; }

    public string Userid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
