using OrderingFoodAPI.Model;
using Microsoft.AspNetCore.Mvc;
using OrderingFoodAPI.DataHelper;
using OrderingFoodAPI.Model.OrderingFoodAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderingFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashierController : ControllerBase
    {
        // GET: api/Cashier
        [HttpGet]
        public ActionResult<IEnumerable<Cashier>> GetCashiers()
        {
            // Fetch all cashiers from in-memory storage
            var cashiers = InMemoryStorage.Cashiers;

            if (cashiers == null || cashiers.Count == 0)
            {
                return NotFound("No cashiers found.");
            }

            return Ok(cashiers);
        }

        // GET: api/Cashier/{id}
        [HttpGet("{id}")]
        public ActionResult<Cashier> GetCashier(int id)
        {
            // Find a specific cashier by ID
            var cashier = InMemoryStorage.Cashiers.FirstOrDefault(c => c.CashierId == id);

            if (cashier == null)
            {
                return NotFound($"Cashier with ID {id} not found.");
            }

            return Ok(cashier);
        }

        // POST: api/Cashier
        [HttpPost]
        public ActionResult<Cashier> CreateCashier([FromBody] Cashier newCashier)
        {
            if (newCashier == null)
            {
                return BadRequest("Cashier data is required.");
            }

            // Generate a new CashierId (assuming you have a way to generate unique IDs)
            newCashier.CashierId = InMemoryStorage.Cashiers.Max(c => c.CashierId) + 1;

            // Add the new cashier to the in-memory storage
            InMemoryStorage.Cashiers.Add(newCashier);

            return CreatedAtAction(nameof(GetCashier), new { id = newCashier.CashierId }, newCashier);
        }

        // PUT: api/Cashier/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCashier(int id, [FromBody] Cashier updatedCashier)
        {
            if (updatedCashier == null)
            {
                return BadRequest("Updated cashier data is required.");
            }

            // Find the existing cashier by ID
            var existingCashier = InMemoryStorage.Cashiers.FirstOrDefault(c => c.CashierId == id);

            if (existingCashier == null)
            {
                return NotFound($"Cashier with ID {id} not found.");
            }

            // Update properties
            existingCashier.Username = updatedCashier.Username;
            existingCashier.FirstName = updatedCashier.FirstName;
            existingCashier.LastName = updatedCashier.LastName;
            existingCashier.Email = updatedCashier.Email;
            existingCashier.PhoneNumber = updatedCashier.PhoneNumber;
            existingCashier.EmploymentDate = updatedCashier.EmploymentDate;

            return NoContent(); // Indicates that the update was successful
        }

        // DELETE: api/Cashier/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCashier(int id)
        {
            // Find the cashier by ID
            var cashier = InMemoryStorage.Cashiers.FirstOrDefault(c => c.CashierId == id);

            if (cashier == null)
            {
                return NotFound($"Cashier with ID {id} not found.");
            }

            // Remove the cashier from the list
            InMemoryStorage.Cashiers.Remove(cashier);

            return NoContent(); // Successfully deleted
        }
    }
}
