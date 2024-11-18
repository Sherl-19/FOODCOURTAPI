using OrderingFoodAPI.Model;

namespace OrderingFoodAPI.Model
{
    public class FoodItem
    {
        public int FoodItemId { get; set; } // Unique identifier for the food item
        public string Name { get; set; } // Name of the food item
        public string Description { get; set; } // Description of the food item
        public string Category { get; set; } // e.g., Fast Food, Beverage, Dessert
        public decimal Price { get; set; } // Price of the food item
        public int Stock { get; set; } // Total available quantity
        public string Status { get; set; } // e.g., Available, Out of Stock

        public ICollection<OrderItem> OrderItems { get; set; } // Link to associated order items
    }
}

