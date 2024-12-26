using System;
using Microsoft.EntityFrameworkCore;
using Toolbox.Dto.Jsonschema;
using Toolbox.Infrastructure;
using Toolbox.Repo.Interfaces;

namespace Toolbox.Repo.Implementations;

public class JsonschemaRepo : IJsonschema
{
    private readonly ToolboxContext _context;
    public JsonschemaRepo(ToolboxContext context)
    {
        _context = context;
    }

    public async Task<List<GetJsonschema>> GetJsonSchemas(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return await _context.Jsonschemas
            .Select(x => new GetJsonschema()
            {
                Id = x.Id,
                Userid = x.Userid,
                Schema = x.Schema,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt
            })
            .ToListAsync();
        }
        return await _context.Jsonschemas
                    .Where(x => x.Userid == userId)
                    .Select(x => new GetJsonschema()
                    {
                        Id = x.Id,
                        Userid = x.Userid,
                        Schema = x.Schema,
                        CreatedAt = x.CreatedAt,
                        ModifiedAt = x.ModifiedAt
                    })
                    .ToListAsync();
    }

    public async Task<GetJsonschema> GetJsonSchemaById(Guid schemaId)
    {
        return await _context.Jsonschemas
                .Where(x => x.Id == schemaId)
                .Select(x => new GetJsonschema()
                {
                    Id = x.Id,
                    Userid = x.Userid,
                    Schema = x.Schema,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt
                }).FirstOrDefaultAsync();
    }

    public async Task<GetJsonschema> CreateJsonSchemaForAdmin(CreateJsonschema payload)
    {
        var jsonschema = new Jsonschema()
        {
            Id = Guid.NewGuid(),
            Userid = payload.Userid,
            Schema = payload.Schema,
            CreatedAt = DateTime.Now,
            ModifiedAt = DateTime.Now
        };

        _context.Add(jsonschema);
        await _context.SaveChangesAsync();
        return new GetJsonschema()
        {
            Id = jsonschema.Id,
            Userid = jsonschema.Userid,
            Schema = jsonschema.Schema,
            CreatedAt = jsonschema.CreatedAt,
            ModifiedAt = jsonschema.ModifiedAt
        };
    }

    public async Task<GetJsonschema> UpdatejsonSchema(Guid schemaId, UpdateJsonschema payload)
    {
        var getSchema = await _context.Jsonschemas.FirstOrDefaultAsync(x => x.Id == schemaId);
        if (getSchema == null)
        {
            throw new Exception("Schema not found");
        }
        getSchema.Schema = payload.Schema;
        getSchema.ModifiedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return new GetJsonschema()
        {
            Id = getSchema.Id,
            Userid = getSchema.Userid,
            Schema = getSchema.Schema,
            CreatedAt = getSchema.CreatedAt,
            ModifiedAt = getSchema.ModifiedAt
        };
    }
}
