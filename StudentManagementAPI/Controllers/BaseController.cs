using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Repositories.Interfaces;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IRepository<T> _repository;

        public BaseController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
                return NotFound($"Item with ID {id} not found.");

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] T item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.AddAsync(item);
            await _repository.SaveAsync();
            return Ok("Item added successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] T item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingItem = await _repository.GetByIdAsync(id);
            if (existingItem == null)
                return NotFound($"Item with ID {id} not found.");

            await _repository.UpdateAsync(item);
            await _repository.SaveAsync();
            return Ok("Item updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingItem = await _repository.GetByIdAsync(id);
            if (existingItem == null)
                return NotFound($"Item with ID {id} not found.");

            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
            return Ok("Item deleted successfully.");
        }
    }
}
