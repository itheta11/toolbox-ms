using System;
using System.Collections.Generic;

namespace Toolbox.Infrastructure;

public partial class JsonItem
{
    public Guid Id { get; set; }

    public string Userid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
