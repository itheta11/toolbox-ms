using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toolbox.Dto.JsonItem;
using Toolbox.Repo.Interfaces;

namespace Toolbox.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    public class JsonItemController : ControllerBase
    {
        private readonly IJsonItem _jsonItem;
        public JsonItemController(IJsonItem jsonItem)
        {
            _jsonItem = jsonItem;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJsonItemsForUser([FromQuery] string userId)
        {
            var getJsonItems = await _jsonItem.GetJsonItemsByUser(userId);
            return Ok(getJsonItems);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllJsonItems()
        {
            var getJsonItems = await _jsonItem.GetJsonItems();
            return Ok(getJsonItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJsonItemById([FromRoute] Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new Exception("Bad request, jsonitemId is missing");
            }
            var getJsonItem = await _jsonItem.GetJsonItemById(id.Value);
            return Ok(getJsonItem);
        }



        [HttpPost]
        public async Task<IActionResult> CreateJsonsItem([FromBody] CreateJsonItem payload)
        {
            var newItem = await _jsonItem.CreateJsonItem(payload);
            return Created(newItem.Id.ToString(), newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJsonItem([FromRoute] Guid? id, [FromBody] UpdateJsonItem payload)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new Exception("Bad request, jsonItemId is missing");
            }
            var newItem = await _jsonItem.UpdateJsonItem(id.Value, payload);
            return Ok(newItem);
        }
    }
}
