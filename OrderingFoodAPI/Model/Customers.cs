using OrderingFoodAPI.Model;
namespace OrderingFoodAPI.Model
{
    public class Customer
    {
        public int CustomerId { get; set; } // Unique identifier for the customer
        public string Username { get; set; } // Username for the customer
        public string FirstName { get; set; } // Customer's first name
        public string LastName { get; set; } // Customer's last name
        public string Email { get; set; } // Customer's email address
        public string Password { get; set; } // Hashed password for login
        public string PhoneNumber { get; set; } // Customer's phone number
        public string Address { get; set; } // Customer's address
        public DateTime MemberSince { get; set; } // Date of account creation
        public string Role { get; set; } // Role, e.g., "Customer", "Admin"

        public ICollection<OrderItem> Orders { get; set; } // Navigation property for customer orders
    }
}
