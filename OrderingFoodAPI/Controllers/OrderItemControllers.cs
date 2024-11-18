using OrderingFoodAPI.Model;
using Microsoft.AspNetCore.Mvc;
using OrderingFoodAPI.DataHelper;
using OrderingFoodAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderingFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        // GET: api/OrderItem
        [HttpGet]
        public ActionResult<IEnumerable<OrderItem>> GetOrderItems()
        {
            // Fetch all order items from in-memory storage
            var orderItems = InMemoryStorage.OrderItems;

            if (orderItems == null || orderItems.Count == 0)
            {
                return NotFound("No order items found.");
            }

            return Ok(orderItems);
        }

        // GET: api/OrderItem/{id}
        [HttpGet("{id}")]
        public ActionResult<OrderItem> GetOrderItem(int id)
        {
            // Find a specific order item by ID
            var orderItem = InMemoryStorage.OrderItems.FirstOrDefault(o => o.OrderItemId == id);

            if (orderItem == null)
            {
                return NotFound($"OrderItem with ID {id} not found.");
            }

            return Ok(orderItem);
        }

        // POST: api/OrderItem
        [HttpPost]
        public ActionResult<OrderItem> CreateOrderItem([FromBody] OrderItem newOrderItem)
        {
            if (newOrderItem == null)
            {
                return BadRequest("OrderItem data is required.");
            }

            // Generate a new OrderItemId (assuming you have a way to generate unique IDs)
            newOrderItem.OrderItemId = InMemoryStorage.OrderItems.Max(o => o.OrderItemId) + 1;

            // Add the new order item to the in-memory storage
            InMemoryStorage.OrderItems.Add(newOrderItem);

            return CreatedAtAction(nameof(GetOrderItem), new { id = newOrderItem.OrderItemId }, newOrderItem);
        }

        // PUT: api/OrderItem/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOrderItem(int id, [FromBody] OrderItem updatedOrderItem)
        {
            if (updatedOrderItem == null)
            {
                return BadRequest("Updated order item data is required.");
            }

            // Find the existing order item by ID
            var existingOrderItem = InMemoryStorage.OrderItems.FirstOrDefault(o => o.OrderItemId == id);

            if (existingOrderItem == null)
            {
                return NotFound($"OrderItem with ID {id} not found.");
            }

            // Update properties
            existingOrderItem.MenuItemId = updatedOrderItem.MenuItemId;
            existingOrderItem.CustomerId = updatedOrderItem.CustomerId;
            existingOrderItem.CashierId = updatedOrderItem.CashierId;
            existingOrderItem.Quantity = updatedOrderItem.Quantity;
            existingOrderItem.OrderDate = updatedOrderItem.OrderDate;
            existingOrderItem.TotalAmount = updatedOrderItem.TotalAmount;
            existingOrderItem.Status = updatedOrderItem.Status;

            return NoContent(); // Indicates that the update was successful
        }

        // DELETE: api/OrderItem/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderItem(int id)
        {
            // Find the order item by ID
            var orderItem = InMemoryStorage.OrderItems.FirstOrDefault(o => o.OrderItemId == id);

            if (orderItem == null)
            {
                return NotFound($"OrderItem with ID {id} not found.");
            }

            // Remove the order item from the list
            InMemoryStorage.OrderItems.Remove(orderItem);

            return NoContent(); // Successfully deleted
        }
    }
}

