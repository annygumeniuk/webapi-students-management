using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories.Implementations;
using StudentManagementAPI.Repositories.Interfaces;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly ILogger<BaseController<T>> _logger;

        public BaseController(IRepository<T> repository, ILogger<BaseController<T>> logger)
        {
            _repository = repository;
            _logger = logger;   
        }


        /// <summary>
        /// Retrieves all items from the database.
        /// </summary>
        /// <returns>A list of items.</returns>
        /// <response code="200">Returns the list of items.</response>        
        /// <response code="500">If an unexpected error occurs.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }

        /// <summary>
        /// Get item details by ID
        /// </summary>
        /// <param name="id">The ID of the item.</param>
        /// <returns>A item object.</returns>
        /// <response code="200">Returns the item object.</response>
        /// <response code="400">If the ID is invalid.</response>
        /// <response code="404">If the item is not found.</response>
        /// <response code="500">If an unexpected error occurs.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
                return NotFound($"Item with ID {id} not found.");

            return Ok(item);
        }

        /// <summary>
        /// Add an item to db
        /// </summary>
        /// <param name="item">A new class object to add</param>
        /// <returns>The added item object.</returns>
        /// <response code="200">Message: Item added successfully.</response>
        /// <response code="400">If the passed item is invalid.</response>        
        /// <response code="500">If an unexpected error occurs.</response>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] T item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                 
            await _repository.AddAsync(item);
            await _repository.SaveAsync();
            return Ok("Item added successfully.");
        }

        /// <summary>
        /// Updates an existing item in the database
        /// </summary>        
        /// <param name="item">The updated item object.</param>
        /// <returns>No content.</returns>
        /// <response code="200">Message: Item updated successfully.</response>
        /// <response code="400">If the provided item is invalid.</response>        
        /// <response code="500">If an unexpected error occurs.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] T item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);            

            await _repository.UpdateAsync(item);
            await _repository.SaveAsync();
            return Ok("Item updated successfully.");
        }

        /// <summary>
        /// Deletes an item from the database by ID
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <returns>No content.</returns>
        /// <response code="200">Message: Item deleted successfully.</response>        
        /// <response code="400">If the passed item is invalid.</response>        
        /// <response code="500">If an unexpected error occurs.</response>
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
