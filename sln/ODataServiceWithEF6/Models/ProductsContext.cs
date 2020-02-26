using ODataServiceWithEF6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ODataServiceWithEF6.Controllers
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base("name=ProductsContext")
        {
            //Database.SetInitializer(new ProductInitializer());
        }

        public DbSet<Product> Products { get; set; }
        // New code:
        public DbSet<Supplier> Suppliers { get; set; }
    }
}