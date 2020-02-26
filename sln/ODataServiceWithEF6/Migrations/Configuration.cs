namespace ODataServiceWithEF6.Migrations
{
    using ODataServiceWithEF6.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ODataServiceWithEF6.Controllers.ProductsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ODataServiceWithEF6.Controllers.ProductsContext context)
        {
            context.Suppliers.AddOrUpdate(new Supplier[]
                {
                    new Supplier() {Id = 11,Name = "Rakel"},
                    new Supplier() {Id = 22, Name = "Warren"},
                });

            context.Products.AddOrUpdate(new Product[] 
            {
                new Product() { Id = 1, Name = "Hat", Price = 15, Category = "Apparel", SupplierId = 11 },
                new Product() { Id = 2, Name = "Socks", Price = 5, Category = "Apparel", SupplierId = 22},
                new Product() { Id = 3, Name = "Scarf", Price = 12, Category = "Apparel", SupplierId = 11},
                new Product() { Id = 4, Name = "Yo-yo", Price = 4.95M, Category = "Toys", SupplierId = 22 },
                new Product() { Id = 5, Name = "Puzzle", Price = 8, Category = "Toys", SupplierId  = 11},
            });

        }
    }
}
