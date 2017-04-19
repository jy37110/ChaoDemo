using MVCPracticeProject.Models;
using MVCPracticeProject.Models.FoodOrder;
using MVCPracticeProject.Models.Tables;

namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCPracticeProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCPracticeProject.Models.ApplicationDbContext";
        }

        protected override void Seed(MVCPracticeProject.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Database.ExecuteSqlCommand("delete from dbo.Products");
            context.Database.ExecuteSqlCommand("delete from dbo.Categories");
            context.Database.ExecuteSqlCommand("delete from dbo.Storages");
            context.Database.ExecuteSqlCommand("delete from dbo.Branches");
            context.Database.ExecuteSqlCommand("delete from dbo.Dishes");
            context.Database.ExecuteSqlCommand("delete from dbo.Orders");
            context.Database.ExecuteSqlCommand("delete from dbo.OrderItems");


            context.Categories.AddOrUpdate(
                c => c.Name,
                new Category { Id = 1, Name = "Fruit" },
                new Category { Id = 2, Name = "Vegetable" },
                new Category { Id = 3, Name = "Meet" }
                );
            context.Products.AddOrUpdate(
                p => p.Name,
                new Product { Id = 1, Name = "Apple", Price = 3.00f, CategoryId = 1 },
                new Product { Id = 2, Name = "Orange", Price = 7.99f, CategoryId = 1 },
                new Product { Id = 3, Name = "Kiwi", Price = 4.99f, CategoryId = 1 },
                new Product { Id = 4, Name = "Onion", Price = 3.99f, CategoryId = 2 },
                new Product { Id = 5, Name = "Carrot", Price = 7.99f, CategoryId = 2 },
                new Product { Id = 6, Name = "Cabbage", Price = 4.99f, CategoryId = 2 },
                new Product { Id = 7, Name = "Beef Steak", Price = 18.99f, CategoryId = 3 },
                new Product { Id = 8, Name = "Chicken Wing", Price = 14.99f, CategoryId = 3 },
                new Product { Id = 9, Name = "Lamb Shin", Price = 16.99f, CategoryId = 3 }
                );
            context.Branches.AddOrUpdate(
                b => b.Name,
                new Branch { Id = 1, Name = "Albany Branch", Address = "Albany Mall", Hours = "8am-8pm 7days", IsAgency = false },
                new Branch { Id = 2, Name = "Glenfield Branch", Address = "Glenfield Mall", Hours = "7am-8pm 7days", IsAgency = false },
                new Branch { Id = 3, Name = "Takapuna Branch", Address = "Takapuna Mall", Hours = "8am-8pm 7days", IsAgency = true }
                );
            context.Storages.AddOrUpdate(s => s.Id,
                new Storage { Id = 1, ProductId = 1, BranchId = 1, StockQty = 10 },
                new Storage { Id = 2, ProductId = 1, BranchId = 2, StockQty = 5 },
                new Storage { Id = 3, ProductId = 1, BranchId = 3, StockQty = 22 },
                new Storage { Id = 4, ProductId = 2, BranchId = 1, StockQty = 5 },
                new Storage { Id = 5, ProductId = 2, BranchId = 2, StockQty = 22 },
                new Storage { Id = 6, ProductId = 2, BranchId = 3, StockQty = 17 },
                new Storage { Id = 7, ProductId = 3, BranchId = 1, StockQty = 44 },
                new Storage { Id = 8, ProductId = 3, BranchId = 2, StockQty = 22 },
                new Storage { Id = 9, ProductId = 3, BranchId = 3, StockQty = 11 },
                new Storage { Id = 10, ProductId = 4, BranchId = 1, StockQty = 15 },
                new Storage { Id = 11, ProductId = 4, BranchId = 2, StockQty = 17 },
                new Storage { Id = 12, ProductId = 4, BranchId = 3, StockQty = 19 },
                new Storage { Id = 13, ProductId = 5, BranchId = 1, StockQty = 16 },
                new Storage { Id = 14, ProductId = 5, BranchId = 2, StockQty = 16 },
                new Storage { Id = 15, ProductId = 5, BranchId = 3, StockQty = 16 },
                new Storage { Id = 16, ProductId = 6, BranchId = 1, StockQty = 44 },
                new Storage { Id = 17, ProductId = 6, BranchId = 2, StockQty = 22 },
                new Storage { Id = 18, ProductId = 6, BranchId = 3, StockQty = 11 },
                new Storage { Id = 19, ProductId = 7, BranchId = 1, StockQty = 15 },
                new Storage { Id = 20, ProductId = 7, BranchId = 2, StockQty = 1 },
                new Storage { Id = 21, ProductId = 7, BranchId = 3, StockQty = 0 },
                new Storage { Id = 22, ProductId = 8, BranchId = 1, StockQty = 2 },
                new Storage { Id = 23, ProductId = 8, BranchId = 2, StockQty = 4 },
                new Storage { Id = 24, ProductId = 8, BranchId = 3, StockQty = 8 },
                new Storage { Id = 25, ProductId = 9, BranchId = 1, StockQty = 18 },
                new Storage { Id = 26, ProductId = 9, BranchId = 2, StockQty = 0 },
                new Storage { Id = 27, ProductId = 9, BranchId = 3, StockQty = 0 }
                );

            context.Dishes.AddOrUpdate(
                c => c.Name,
                new Dish { Name = "Catch of the day", Details = "Herb ristto, spanner crab, dried tomatoes, mustard leaves lemon oil.", Price = 44.00m, Type = "Main Course"},
                new Dish { Name = "Pan-fried snapper", Details = "Chilli coconut broth crispy prawn, vietnamese mint salad.", Price = 42.00m, Type = "Main Course" },
                new Dish { Name = "Long line tarakihi", Details = "Beer battered, duck fat chips, warm pea salad, tartare, lemon, Sails ketchup.", Price = 37.00m, Type = "Main Course" },
                new Dish { Name = "Walewska", Details = "Steamed catch, mornay, prawns, truffle dressing, spinach, duchess potatoes.", Price = 49.00m, Type = "Main Course" },
                new Dish { Name = "Roast duck breast", Details = "Confit duck leg, pink peppercorn crust, kumara mash, beetroot, cherry gastrique and salmis sauce.", Price = 44.00m, Type = "Main Course" },
                new Dish { Name = "Dauphinoise potatoes", Details = "", Price = 10.00m, Type = "Sides" },
                new Dish { Name = "Broccolini", Details = "Golden raisin, almond butter.", Price = 10.00m, Type = "Sides" },
                new Dish { Name = "Fries", Details = "Truffle oil, parnesan.", Price = 10.00m, Type = "Sides" },
                new Dish { Name = "Salad", Details = "Mixed leaves, pear, walnut.", Price = 10.00m, Type = "Sides" },
                new Dish { Name = "Sorbets & ice creams", Details = "Sugar coated pumpkin seeds, caramelized white chocolate.", Price = 15.00m, Type = "Desserts" },
                new Dish { Name = "Pavlova", Details = "Passion fruit curd, whipped cream.", Price = 15.00m, Type = "Desserts" },
                new Dish { Name = "Red gold", Details = "Textures of berry, sorbet, spicy caramel top.", Price = 16.00m, Type = "Desserts" },
                new Dish { Name = "Sails donuts", Details = "Apples, rum and cranberry ice cream.", Price = 16.00m, Type = "Desserts" },
                new Dish { Name = "Flat white", Details = "", Price = 5.00m, Type = "Coffee" },
                new Dish { Name = "Latte", Details = "", Price = 5.00m, Type = "Coffee" },
                new Dish { Name = "Cappuccino", Details = "", Price = 5.00m, Type = "Coffee" },
                new Dish { Name = "Long black", Details = "", Price = 5.00m, Type = "Coffee" },
                new Dish { Name = "Short black", Details = "", Price = 5.00m, Type = "Coffee" },
                new Dish { Name = "Macchiato", Details = "", Price = 5.00m, Type = "Coffee" },
                new Dish { Name = "Ristretto", Details = "", Price = 5.00m, Type = "Coffee" },
                new Dish { Name = "English breakfast", Details = "", Price = 5.00m, Type = "Tea" },
                new Dish { Name = "Aromatic earl grey", Details = "", Price = 5.00m, Type = "Tea" },
                new Dish { Name = "Pure green tea", Details = "", Price = 5.00m, Type = "Tea" },
                new Dish { Name = "Gentle chamomile", Details = "", Price = 5.00m, Type = "Tea" },
                new Dish { Name = "Pure peppermint", Details = "", Price = 5.00m, Type = "Tea" }
            );
        }
    }
}
