using System;
using Toolbox.Dto.Article;

namespace Toolbox.Repo.Interfaces;

public interface IArticleRepo
{
    Task<List<GetArticle>> GetAllArticle();
    Task<List<GetArticle>> GetAllArticleByUser(string userId);
    Task<GetArticle> GetArticleById(Guid drawingId);
    Task<GetArticle> CreateArticle(CreatArticle payload);
    Task<GetArticle> UpdateArticle(Guid drawingId, UpdateArticle payload);
}
