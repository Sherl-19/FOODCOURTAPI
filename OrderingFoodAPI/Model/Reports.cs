using System;

namespace OrderingFoodAPI.Model
{
    public class Report
    {
        // Tracks total sales and revenue for each menu item
        public class SalesReport
        {
            public int MenuItemId { get; set; }
            public string Name { get; set; }
            public int TotalSales { get; set; } // Total quantity sold
            public decimal TotalRevenue { get; set; } // Total revenue generated
        }

        // Tracks individual customer activity
        public class CustomerActivityReport
        {
            public string CustomerName { get; set; }
            public int TotalOrders { get; set; } // Total number of orders placed
            public decimal TotalSpent { get; set; } // Total money spent by the customer
        }

        // Tracks menu item performance over a time period
        public class MenuItemPerformanceReport
        {
            public int MenuItemId { get; set; }
            public string Name { get; set; }
            public int TotalSales { get; set; } // Total quantity sold
            public decimal AverageDailySales { get; set; } // Average daily sales
            public decimal TotalRevenue { get; set; } // Total revenue generated
        }
    }
}
