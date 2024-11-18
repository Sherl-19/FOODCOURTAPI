namespace OrderingFoodAPI.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int MenuItemId { get; set; }
        public int CustomerId { get; set; }
        public int CashierId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }  // e.g., Pending, Completed, etc.
    }
}
