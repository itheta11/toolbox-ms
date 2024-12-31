using System;
using Microsoft.EntityFrameworkCore;
using Toolbox.Dto.JsonItem;
using Toolbox.Infrastructure;
using Toolbox.Repo.Interfaces;

namespace Toolbox.Repo.Implementations;

public class JsonItemRepo : IJsonItem
{
    private readonly ToolboxContext _context;
    public JsonItemRepo(ToolboxContext context)
    {
        _context = context;
    }

    public async Task<GetJsonItem> CreateJsonItem(CreateJsonItem payload)
    {

        var jsonItem = new JsonItem()
        {
            Id = Guid.NewGuid(),
            Userid = payload.Userid,
            Title = payload.Title,
            Value = payload.Value,
            CreatedAt = DateTime.Now, /// ef core can think of a db variable to store db datetime
            ModifiedAt = DateTime.Now
        };
        _context.Add(jsonItem);
        await _context.SaveChangesAsync();

        return new GetJsonItem()
        {
            Id = jsonItem.Id,
            Userid = jsonItem.Userid,
            Title = jsonItem.Title,
            Value = jsonItem.Value,
            CreatedAt = jsonItem.CreatedAt,
            ModifiedAt = jsonItem.ModifiedAt
        };
    }

    public async Task<GetJsonItem> GetJsonItemById(Guid schemaId)
    {
        var getJsonItem = await _context.JsonItems
            .Where(x => x.Id == schemaId)
            .Select(x => new GetJsonItem()
            {
                Id = x.Id,
                Title = x.Title,
                Value = x.Value,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt

            }).FirstOrDefaultAsync();

        if (getJsonItem == null)
        {
            throw new Exception("JsonItem not found");
        }

        return getJsonItem;
    }

    public async Task<List<GetJsonItem>> GetJsonItems()
    {
        return await _context.JsonItems
            .Select(x => new GetJsonItem()
            {
                Id = x.Id,
                Title = x.Title,
                Value = x.Value,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt

            }).ToListAsync();
    }

    public async Task<List<GetJsonItem>> GetJsonItemsByUser(string userId)
    {
        return await _context.JsonItems
            .Where(x => x.Userid == userId)
            .Select(x => new GetJsonItem()
            {
                Id = x.Id,
                Title = x.Title,
                Value = x.Value,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt

            }).ToListAsync();
    }

    public async Task<GetJsonItem> UpdateJsonItem(Guid id, UpdateJsonItem payload)
    {
        var getJsonItem = await _context.JsonItems
            .FirstOrDefaultAsync(x => x.Id == id);

        if (getJsonItem == null)
        {
            throw new Exception("Drawing not found");
        }

        getJsonItem.Title = payload.Title;
        getJsonItem.Value = payload.Value;
        getJsonItem.ModifiedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return new GetJsonItem()
        {
            Id = getJsonItem.Id,
            Userid = getJsonItem.Userid,
            Title = getJsonItem.Title,
            Value = getJsonItem.Value,
            CreatedAt = getJsonItem.CreatedAt,
            ModifiedAt = getJsonItem.ModifiedAt
        };
    }
}
