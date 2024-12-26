using System;
using Microsoft.EntityFrameworkCore;
using Toolbox.Dto.Cheatsheet;
using Toolbox.Infrastructure;
using Toolbox.Repo.Interfaces;

namespace Toolbox.Repo.Implementations;

public class CheatsheetRepo : ICheatsheetRepo
{
    private readonly ToolboxContext _context;
    public CheatsheetRepo(ToolboxContext context)
    {
        _context = context;
    }

    public async Task<GetCheatsheet> CreateCheatsheet(CreateCheatsheet payload)
    {
        var cheatsheet = new Cheatsheet()
        {
            Id = Guid.NewGuid(),
            Userid = payload.Userid,
            Title = payload.Title,
            Content = payload.Content,
            CreatedAt = DateTime.Now, /// ef core can think of a db variable to store db datetime
            ModifiedAt = DateTime.Now
        };
        _context.Add(cheatsheet);
        await _context.SaveChangesAsync();

        return new GetCheatsheet()
        {
            Id = cheatsheet.Id,
            Userid = cheatsheet.Userid,
            Title = cheatsheet.Title,
            Content = cheatsheet.Content,
            CreatedAt = cheatsheet.CreatedAt,
            ModifiedAt = cheatsheet.ModifiedAt
        };
    }

    public async Task<List<GetCheatsheet>> GetAllCheatsheet()
    {
        return await _context.Cheatsheets
        .Select(x => new GetCheatsheet()
        {
            Id = x.Id,
            Userid = x.Userid,
            Title = x.Title,
            Content = x.Content,
            CreatedAt = x.CreatedAt,
            ModifiedAt = x.ModifiedAt
        })
        .ToListAsync();
    }

    public async Task<List<GetCheatsheet>> GetAllCheatsheetByUser(string userId)
    {
        return await _context.Cheatsheets
        .Where(x => x.Userid == userId)
        .Select(x => new GetCheatsheet()
        {
            Id = x.Id,
            Userid = x.Userid,
            Title = x.Title,
            Content = x.Content,
            CreatedAt = x.CreatedAt,
            ModifiedAt = x.ModifiedAt
        })
        .ToListAsync();
    }

    public async Task<GetCheatsheet> GetCheatsheetById(Guid cheatheetId)
    {
        var getCheatsheet = await _context.Cheatsheets
        .Where(x => x.Id == cheatheetId)
        .Select(x => new GetCheatsheet()
        {
            Id = x.Id,
            Userid = x.Userid,
            Title = x.Title,
            Content = x.Content,
            CreatedAt = x.CreatedAt,
            ModifiedAt = x.ModifiedAt
        })
        .FirstOrDefaultAsync();

        if (getCheatsheet == null)
        {
            throw new Exception("Cheatsheet not found");
        }
        return getCheatsheet;
    }

    public async Task<GetCheatsheet> UpdateCheatsheet(Guid cheatsheetId, UpdateCheatsheet payload)
    {
        var getCheatsheet = await _context.Cheatsheets
            .FirstOrDefaultAsync(x => x.Id == cheatsheetId);

        if (getCheatsheet == null)
        {
            throw new Exception("Drawing not found");
        }

        getCheatsheet.Title = payload.Title;
        getCheatsheet.Content = payload.Content;
        getCheatsheet.ModifiedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return new GetCheatsheet()
        {
            Id = getCheatsheet.Id,
            Userid = getCheatsheet.Userid,
            Title = getCheatsheet.Title,
            Content = getCheatsheet.Content,
            CreatedAt = getCheatsheet.CreatedAt,
            ModifiedAt = getCheatsheet.ModifiedAt
        };
    }
}
