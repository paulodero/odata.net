using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using ODataServiceWithEF6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ODataServiceWithEF6
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            // New code:
            builder.EntitySet<Supplier>("Suppliers");

            var function = builder.EntityType<Product>().Collection.Function("PrimtiveFunction").Returns<List<Product>>();

            config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();

            var functions = builder.EntityType<Product>().Collection.Function("MyFunction").Returns<string>();
            function.Parameter<int>("p1");
            function.Parameter<int?>("p2");
            function.CollectionParameter<int>("p3");

            config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());
        }
    }
}
