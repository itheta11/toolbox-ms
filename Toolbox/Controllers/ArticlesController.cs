using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toolbox.Dto.Article;
using Toolbox.Repo.Interfaces;

namespace Toolbox.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepo _article;
        public ArticlesController(IArticleRepo article)
        {
            _article = article;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllArticles()
        {
            var getArticles = await _article.GetAllArticle();
            return Ok(getArticles);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticleForUser([FromQuery] string userId)
        {
            var getArticles = await _article.GetAllArticleByUser(userId);
            return Ok(getArticles);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById([FromRoute] Guid? id)
        {
            var getArticle = await _article.GetArticleById(id.Value);
            return Ok(getArticle);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] CreatArticle payload)
        {
            var getArticle = await _article.CreateArticle(payload);
            return Created(getArticle.Id.ToString(), getArticle);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle([FromRoute] Guid? id, [FromBody] UpdateArticle payload)
        {
            var getArticle = await _article.UpdateArticle(id.Value, payload);
            return Ok(getArticle);
        }

    }
}
