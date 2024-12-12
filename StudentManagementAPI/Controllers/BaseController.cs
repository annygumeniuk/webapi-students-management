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
            _logger.LogInformation("Entered GetAll method.");

            try
            {
                var items = await _repository.GetAllAsync();
                _logger.LogInformation("Successfully retrieved all items.");
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all items.");
                return StatusCode(500, "Internal server error");
            }
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
            _logger.LogInformation("Entered GetById method with id: {Id}.", id);
            try
            {
                var item = await _repository.GetByIdAsync(id);
                if (item == null)
                {
                    _logger.LogWarning("Item with ID {Id} not found.", id);
                    return NotFound($"Item with ID {id} not found.");
                }

                _logger.LogInformation("Successfully retrieved item with ID {Id}.", id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving item with ID {Id}.", id);
                return StatusCode(500, "Internal server error");
            }
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
            _logger.LogInformation("Entered Add method.");

            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Model state is invalid.");
                    return BadRequest(ModelState);
                }

                await _repository.AddAsync(item);
                await _repository.SaveAsync();
                _logger.LogInformation("Item added successfully.");
                return Ok("Item added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new item.");
                return StatusCode(500, "Internal server error");
            }           
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
            _logger.LogInformation("Entered Update method.");
            try 
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Model state is invalid.");
                    return BadRequest(ModelState);
                }                   

                await _repository.UpdateAsync(item);
                await _repository.SaveAsync();
                _logger.LogInformation("Item updated successfully.");
                return Ok("Item updated successfully.");
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error occurred while updating item.");
                return StatusCode(500, "Internal server error");
            }            
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
            _logger.LogInformation("Entered Delete method with ID {Id}.", id);

            try
            {
                var existingItem = await _repository.GetByIdAsync(id);
                if (existingItem == null)
                {
                    _logger.LogWarning("Item with ID {Id} not found.", id);
                    return NotFound($"Item with ID {id} not found.");
                }                

                await _repository.DeleteAsync(id);
                await _repository.SaveAsync();
                _logger.LogInformation("Successfully deleted item with ID {Id}.", id);
                return Ok("Item deleted successfully.");
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error occurred while deleting item with ID {Id}.", id);
                return StatusCode(500, "Internal server error");
            }           
        }
    }
}
