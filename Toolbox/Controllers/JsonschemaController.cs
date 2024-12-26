using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toolbox.Dto.Jsonschema;
using Toolbox.Repo.Interfaces;

namespace Toolbox.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    public class JsonschemasController : ControllerBase
    {
        private readonly IJsonschema _jsonSchema;
        public JsonschemasController(IJsonschema jsonschema)
        {
            _jsonSchema = jsonschema;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJsonSchemaForUser([FromQuery] string userId)
        {
            var getSchemas = await _jsonSchema.GetJsonSchemas(userId);
            return Ok(getSchemas);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllJsonSchema()
        {
            var getSchemas = await _jsonSchema.GetJsonSchemas(null);
            return Ok(getSchemas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJsonSchemaById([FromRoute] Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new Exception("Bad request, scheamId is missing");
            }
            var getSchemas = await _jsonSchema.GetJsonSchemaById(id.Value);
            return Ok(getSchemas);
        }



        [HttpPost]
        public async Task<IActionResult> CreateJsonschema([FromBody] CreateJsonschema payload)
        {
            var newschema = await _jsonSchema.CreateJsonSchemaForAdmin(payload);
            return Created(newschema.Id.ToString(), newschema);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJsonschema([FromRoute] Guid? id, [FromBody] UpdateJsonschema payload)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new Exception("Bad request, scheamId is missing");
            }
            var newschema = await _jsonSchema.UpdatejsonSchema(id.Value, payload);
            return Ok(newschema);
        }
    }
}
