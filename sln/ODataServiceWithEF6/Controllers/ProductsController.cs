using Microsoft.AspNet.OData;
using ODataServiceWithEF6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ODataServiceWithEF6.Controllers
{
    public class ProductsController : ODataController
    {

        ProductsContext db = new ProductsContext();
        // GET /Products(1)/Supplier
        [EnableQuery]
        public SingleResult<Supplier> GetSupplier([FromODataUri] int key)
        {
            var result = db.Products.Where(m => m.Id == key).Select(m => m.Supplier);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return db.Products;
        }

        [EnableQuery]
        public IQueryable<Product> PrimtiveFunction()
        {
            return db.Products;
        }

        [HttpGet]
        public List<Product> MyFunction(int p1, int? p2, [FromODataUri]IEnumerable<int> p3)
        {
            //return db.Products;
            return null;
        }

    }
}