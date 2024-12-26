using System;
using Microsoft.EntityFrameworkCore;
using Toolbox.Dto.Article;
using Toolbox.Infrastructure;
using Toolbox.Repo.Interfaces;

namespace Toolbox.Repo.Implementations;

public class ArticleRepo : IArticleRepo
{
    private readonly ToolboxContext _context;
    public ArticleRepo(ToolboxContext context)
    {
        _context = context;
    }

    public async Task<GetArticle> CreateArticle(CreatArticle payload)
    {
        var drawing = new ExacliDrawing()
        {
            Id = Guid.NewGuid(),
            Userid = payload.Userid,
            Title = payload.Title,
            Content = payload.Content,
            CreatedAt = DateTime.Now, /// ef core can think of a db variable to store db datetime
            ModifiedAt = DateTime.Now
        };
        _context.Add(drawing);
        await _context.SaveChangesAsync();

        return new GetArticle()
        {
            Id = drawing.Id,
            Userid = drawing.Userid,
            Title = drawing.Title,
            Content = drawing.Content,
            CreatedAt = drawing.CreatedAt,
            ModifiedAt = drawing.ModifiedAt
        };
    }

    public async Task<List<GetArticle>> GetAllArticle()
    {
        return await _context.ExacliDrawings
        .Select(x => new GetArticle()
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

    public async Task<List<GetArticle>> GetAllArticleByUser(string userId)
    {
        return await _context.ExacliDrawings
        .Where(x => x.Userid == userId)
        .Select(x => new GetArticle()
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

    public async Task<GetArticle> GetArticleById(Guid drawingId)
    {
        var getArticle = await _context.ExacliDrawings
        .Where(x => x.Id == drawingId)
        .Select(x => new GetArticle()
        {
            Id = x.Id,
            Userid = x.Userid,
            Title = x.Title,
            Content = x.Content,
            CreatedAt = x.CreatedAt,
            ModifiedAt = x.ModifiedAt
        })
        .FirstOrDefaultAsync();

        if (getArticle == null)
        {
            throw new Exception("Drawing not found");
        }
        return getArticle;
    }

    public async Task<GetArticle> UpdateArticle(Guid drawingId, UpdateArticle payload)
    {
        var getArticle = await _context.ExacliDrawings
            .FirstOrDefaultAsync(x => x.Id == drawingId);

        if (getArticle == null)
        {
            throw new Exception("Drawing not found");
        }

        getArticle.Title = payload.Title;
        getArticle.Content = payload.Content;
        getArticle.ModifiedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return new GetArticle()
        {
            Id = getArticle.Id,
            Userid = getArticle.Userid,
            Title = getArticle.Title,
            Content = getArticle.Content,
            CreatedAt = getArticle.CreatedAt,
            ModifiedAt = getArticle.ModifiedAt
        };
    }
}
