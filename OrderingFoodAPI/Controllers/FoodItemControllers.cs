using Microsoft.AspNetCore.Mvc;
using OrderingFoodAPI.DataHelper;
using OrderingFoodAPI.Model;

namespace OrderingFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        // GET: api/FoodItem
        [HttpGet]
        public ActionResult<IEnumerable<FoodItem>> GetFoodItems()
        {
            // Return all food items from in-memory storage
            return Ok(InMemoryStorage.FoodItems);
        }

        // GET: api/FoodItem/5
        [HttpGet("{id}")]
        public ActionResult<FoodItem> GetFoodItem(int id)
        {
            // Find the food item by ID
            var foodItem = InMemoryStorage.FoodItems.FirstOrDefault(f => f.FoodItemId == id);
            if (foodItem == null)
            {
                return NotFound();
            }
            return Ok(foodItem);
        }

        // POST: api/FoodItem
        [HttpPost]
        public ActionResult<FoodItem> PostFoodItem(FoodItem foodItem)
        {
            // Generate a new ID (in a real database, this would be handled by the DB itself)
            var newId = InMemoryStorage.FoodItems.Max(f => f.FoodItemId) + 1;
            foodItem.FoodItemId = newId;

            // Add the food item to the in-memory storage
            InMemoryStorage.FoodItems.Add(foodItem);

            // Return the created food item with a status code 201
            return CreatedAtAction(nameof(GetFoodItem), new { id = foodItem.FoodItemId }, foodItem);
        }

        // PUT: api/FoodItem/5
        [HttpPut("{id}")]
        public IActionResult PutFoodItem(int id, FoodItem foodItem)
        {
            // Find the food item by ID
            var existingFoodItem = InMemoryStorage.FoodItems.FirstOrDefault(f => f.FoodItemId == id);
            if (existingFoodItem == null)
            {
                return NotFound();
            }

            // Update the food item details
            existingFoodItem.Name = foodItem.Name;
            existingFoodItem.Price = foodItem.Price;
            existingFoodItem.Stock = foodItem.Stock;

            return NoContent(); // Return 204 No Content status indicating successful update
        }

        // DELETE: api/FoodItem/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFoodItem(int id)
        {
            // Find the food item by ID
            var foodItem = InMemoryStorage.FoodItems.FirstOrDefault(f => f.FoodItemId == id);
            if (foodItem == null)
            {
                return NotFound();
            }

            // Remove the food item from the list
            InMemoryStorage.FoodItems.Remove(foodItem);

            return NoContent(); // Return 204 No Content status indicating successful deletion
        }
    }
}
