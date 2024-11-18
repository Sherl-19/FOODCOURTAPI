using OrderingFoodAPI.Model;

namespace OrderingFoodAPI.Model
{
    public class MenuItem
    {
        public int MenuItemId { get; set; } // Unique identifier for the menu item
        public string Name { get; set; } // Name of the menu item
        public string Description { get; set; } // Description of the menu item
        public string Category { get; set; } // Category, e.g., "Fast Food", "Beverages", "Desserts"
        public decimal Price { get; set; } // Price of the menu item
        public string Status { get; set; } // e.g., "Available", "Unavailable"

        public int FoodItemId { get; set; } // Link to FoodItem (optional for detailed management)
        public FoodItem FoodItem { get; set; } // Navigation property for detailed stock or tracking

        public ICollection<OrderItem> OrderItems { get; set; } // Links this menu item to its order items
    }
}

