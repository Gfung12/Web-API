using Microsoft.AspNetCore.Mvc;
using Web_API.Services;

namespace Web_API.Controllers
{
    [Route("linked-list")]
    [ApiController]
    public class LinkedListController : ControllerBase
    {
        private readonly LinkedListService _linkedListService;

        public LinkedListController(LinkedListService linkedListService)
        {
            _linkedListService = linkedListService;
        }

        // GET /linked-list/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_linkedListService.GetAllNodes());
        }

        // POST /linked-list/
        [HttpPost]
        public IActionResult Post([FromBody] dynamic data)
        {
            string value = data.GetProperty("value").GetString();
            var id = _linkedListService.AddNode(value);
            return Ok(new { Id = id });
        }

        // DELETE /linked-list/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            bool removed = _linkedListService.RemoveNode(id);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}
