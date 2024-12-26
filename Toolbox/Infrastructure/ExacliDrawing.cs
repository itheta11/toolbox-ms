using System;
using System.Collections.Generic;

namespace Toolbox.Infrastructure;

public partial class ExacliDrawing
{
    public Guid Id { get; set; }

    public string Userid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
