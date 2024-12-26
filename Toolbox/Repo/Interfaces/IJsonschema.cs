using System;
using Toolbox.Dto.Jsonschema;
using Toolbox.Infrastructure;

namespace Toolbox.Repo.Interfaces;

public interface IJsonschema
{
    Task<List<GetJsonschema>> GetJsonSchemas(string userId);
    Task<GetJsonschema> GetJsonSchemaById(Guid schemaId);
    Task<GetJsonschema> CreateJsonSchemaForAdmin(CreateJsonschema payload);
    Task<GetJsonschema> UpdatejsonSchema(Guid schemaId, UpdateJsonschema payload);
}
