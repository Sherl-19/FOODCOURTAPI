using OrderingFoodAPI.Model;
using OrderingFoodAPI.Model.OrderingFoodAPI.Model;
using OrderingFoodAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using static OrderingFoodAPI.Model.Report;

namespace OrderingFoodAPI.DataHelper
{
    public static class InMemoryStorage
    {
        public static string salt = ")GN#447#^nryrETNwrbR%#&NBRE%#%BBDT#%";

        // Lists to store MenuItems, FoodItems, OrderItems, Customers, Cashiers, and Reports
        public static List<MenuItem> MenuItems = new List<MenuItem>();
        public static List<FoodItem> FoodItems = new List<FoodItem>();
        public static List<OrderItem> OrderItems = new List<OrderItem>();
        public static List<Customer> Customers = new List<Customer>
        {
            // Seed Customers
            new Customer
            {
                CustomerId = 1,
                Username = "admin",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "dde6a80ee27ed148c86020e2cfaf6d28", // Hashed password
                PhoneNumber = "+1234567890",
                Address = "123 Elm Street, Springfield, IL",
                MemberSince = new DateTime(2020, 5, 1),
                Role = "Customer"
            },
            new Customer
            {
                CustomerId = 2,
                Username = "Jane",
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Password = "6cb75f652a9b52798eb6cf2201057c73", // Hashed password
                PhoneNumber = "+1987654321",
                Address = "456 Oak Avenue, Springfield, IL",
                MemberSince = new DateTime(2021, 3, 15),
                Role = "Customer"
            }
        };

        public static List<Cashier> Cashiers = new List<Cashier>
        {
            // Seed Cashiers
            new Cashier
            {
                CashierId = 1,
                Username = "cashier1",
                FirstName = "Alice",
                LastName = "Brown",
                Email = "alice.brown@example.com",
                Password = "12345hashedpassword",
                PhoneNumber = "+1239876543",
                EmploymentDate = new DateTime(2019, 7, 10)
            },
            new Cashier
            {
                CashierId = 2,
                Username = "cashier2",
                FirstName = "Bob",
                LastName = "Green",
                Email = "bob.green@example.com",
                Password = "67890hashedpassword",
                PhoneNumber = "+1987543210",
                EmploymentDate = new DateTime(2020, 2, 20)
            }
        };

        public static List<SalesReport> SalesReports = new List<SalesReport>();
        public static List<CustomerActivityReport> CustomerActivityReports = new List<CustomerActivityReport>();

        static InMemoryStorage()
        {
            // Seed MenuItems
            MenuItems.Add(new MenuItem { MenuItemId = 1, Name = "Burger Combo", Price = 12.99m, Category = "Fast Food", Description = "Burger with fries and a drink", Status = "Available" });
            MenuItems.Add(new MenuItem { MenuItemId = 2, Name = "Pizza Slice", Price = 3.99m, Category = "Fast Food", Description = "Single slice of cheese pizza", Status = "Available" });

            // Seed FoodItems
            FoodItems.Add(new FoodItem { FoodItemId = 1, Name = "Burger", Price = 5.99m, Stock = 50 });
            FoodItems.Add(new FoodItem { FoodItemId = 2, Name = "Fries", Price = 2.99m, Stock = 40 });
            FoodItems.Add(new FoodItem { FoodItemId = 3, Name = "Drink", Price = 1.99m, Stock = 60 });

            // Seed OrderItems
            OrderItems.Add(new OrderItem
            {
                OrderItemId = 1,
                MenuItemId = 1,
                CustomerId = 1,
                CashierId = 1,
                Quantity = 2,
                OrderDate = DateTime.Now.AddDays(-5),
                TotalAmount = 25.98m,
                Status = "Completed"
            });
            OrderItems.Add(new OrderItem
            {
                OrderItemId = 2,
                MenuItemId = 2,
                CustomerId = 2,
                CashierId = 2,
                Quantity = 3,
                OrderDate = DateTime.Now.AddDays(-2),
                TotalAmount = 11.97m,
                Status = "Pending"
            });

            // Seed Sales Reports
            SalesReports.Add(new SalesReport { MenuItemId = 1, Name = "Burger Combo", TotalSales = 50 });
            SalesReports.Add(new SalesReport { MenuItemId = 2, Name = "Pizza Slice", TotalSales = 100 });

            // Seed Customer Activity Reports
            CustomerActivityReports.Add(new CustomerActivityReport { CustomerName = "John Doe", TotalOrders = 10, TotalSpent = 120.50m });
            CustomerActivityReports.Add(new CustomerActivityReport { CustomerName = "Jane Smith", TotalOrders = 5, TotalSpent = 45.00m });
        }
    }
}
