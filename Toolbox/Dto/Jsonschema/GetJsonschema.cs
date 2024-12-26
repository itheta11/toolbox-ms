using System;

namespace Toolbox.Dto.Jsonschema;

public class GetJsonschema
{
    public Guid Id { get; set; }

    public string Userid { get; set; } = null!;

    public string Schema { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
