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
    public class CustomerController : ControllerBase
    {
        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            // Fetch all customers from in-memory storage
            var customers = InMemoryStorage.Customers;

            if (customers == null || customers.Count == 0)
            {
                return NotFound("No customers found.");
            }

            return Ok(customers);
        }

        // GET: api/Customer/{id}
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            // Find a specific customer by ID
            var customer = InMemoryStorage.Customers.FirstOrDefault(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> CreateCustomer([FromBody] Customer newCustomer)
        {
            if (newCustomer == null)
            {
                return BadRequest("Customer data is required.");
            }

            // Generate a new CustomerId (assuming you have a way to generate unique IDs)
            newCustomer.CustomerId = InMemoryStorage.Customers.Max(c => c.CustomerId) + 1;

            // Add the new customer to the in-memory storage
            InMemoryStorage.Customers.Add(newCustomer);

            return CreatedAtAction(nameof(GetCustomer), new { id = newCustomer.CustomerId }, newCustomer);
        }

        // PUT: api/Customer/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            if (updatedCustomer == null)
            {
                return BadRequest("Updated customer data is required.");
            }

            // Find the existing customer by ID
            var existingCustomer = InMemoryStorage.Customers.FirstOrDefault(c => c.CustomerId == id);

            if (existingCustomer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

            // Update properties
            existingCustomer.Username = updatedCustomer.Username;
            existingCustomer.FirstName = updatedCustomer.FirstName;
            existingCustomer.LastName = updatedCustomer.LastName;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            existingCustomer.Address = updatedCustomer.Address;
            existingCustomer.Role = updatedCustomer.Role;
            existingCustomer.MemberSince = updatedCustomer.MemberSince;

            return NoContent(); // Indicates that the update was successful
        }

        // DELETE: api/Customer/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            // Find the customer by ID
            var customer = InMemoryStorage.Customers.FirstOrDefault(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

            // Remove the customer from the list
            InMemoryStorage.Customers.Remove(customer);

            return NoContent(); // Successfully deleted
        }
    }
}
