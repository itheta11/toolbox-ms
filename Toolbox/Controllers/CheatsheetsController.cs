using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toolbox.Dto.Cheatsheet;
using Toolbox.Repo.Interfaces;

namespace Toolbox.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    public class CheatsheetsController : ControllerBase
    {
        private readonly ICheatsheetRepo _cheatsheetRepo;
        public CheatsheetsController(ICheatsheetRepo cheatsheetRepo)
        {
            _cheatsheetRepo = cheatsheetRepo;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllCheatsheets()
        {
            var getCheatsheet = await _cheatsheetRepo.GetAllCheatsheet();
            return Ok(getCheatsheet);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCheatsheetForUser([FromQuery] string userId)
        {
            var getCheatsheet = await _cheatsheetRepo.GetAllCheatsheetByUser(userId);
            return Ok(getCheatsheet);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCheatsheetById([FromRoute] Guid? id)
        {
            var getCheatsheet = await _cheatsheetRepo.GetCheatsheetById(id.Value);
            return Ok(getCheatsheet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheatsheet([FromBody] CreateCheatsheet payload)
        {
            var getCheatsheet = await _cheatsheetRepo.CreateCheatsheet(payload);
            return Created(getCheatsheet.Id.ToString(), getCheatsheet);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCheatsheet([FromRoute] Guid? id, [FromBody] UpdateCheatsheet payload)
        {
            var getCheatsheet = await _cheatsheetRepo.UpdateCheatsheet(id.Value, payload);
            return Ok(getCheatsheet);
        }

    }
}
