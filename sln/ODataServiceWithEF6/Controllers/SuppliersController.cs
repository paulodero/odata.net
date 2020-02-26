using Microsoft.AspNet.OData;
using ODataServiceWithEF6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataServiceWithEF6.Controllers
{
    public class SuppliersController : ODataController
    {
        ProductsContext db = new ProductsContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // GET /Suppliers(1)/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts([FromODataUri] int key)
        {
            return db.Suppliers.Where(m => m.Id.Equals(key)).SelectMany(m => m.Products);
        }
    }
}