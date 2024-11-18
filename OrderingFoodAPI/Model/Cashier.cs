namespace OrderingFoodAPI.Model
{
    namespace OrderingFoodAPI.Model
    {
        public class Cashier
        {
            public int CashierId { get; set; } // Unique identifier for the cashier
            public string Username { get; set; } // Username for login
            public string FirstName { get; set; } // Cashier's first name
            public string LastName { get; set; } // Cashier's last name
            public string Email { get; set; } // Cashier's email address
            public string Password { get; set; } // Hashed password for secure authentication
            public string PhoneNumber { get; set; } // Cashier's phone number (optional)
            public DateTime EmploymentDate { get; set; } // Date when the cashier started employment
            public string Role { get; set; } // Role, e.g., "Cashier", "Manager"

            public ICollection<OrderItem> ProcessedOrders { get; set; } // Orders processed by the cashier
        }
    }
}

