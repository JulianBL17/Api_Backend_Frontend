using ApiService.Models;
using ApiService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly IToolRepository _toolRepository;
        public ToolsController(IToolRepository toolRepository)
        {
            _toolRepository = toolRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Tool>> GetTools()
        {
            return await _toolRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tool>> GetTools(int id)
        {
            return await _toolRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Tool>>PostTools([FromBody] Tool tool)
        {
            var newBook = await _toolRepository.Create(tool);
            return CreatedAtAction(nameof(GetTools), new { id = newBook.Id }, newBook);
        }

        [HttpPut]
        public async Task<ActionResult> PutTools(int id, [FromBody] Tool tool)
        {
            if(id != tool.Id)
            {
                return BadRequest();
            }

            await _toolRepository.Update(tool);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var toolToDelete = await _toolRepository.Get(id);
            if (toolToDelete == null)
                return NotFound();

            await _toolRepository.Delete(toolToDelete.Id);
            return NoContent();
        }
    }
}