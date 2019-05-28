using System;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Query;
using Microsoft.OData.Edm;
using ODataServiceAdventureWorks.Models;

namespace ODataServiceAdventureWorks
{
    internal static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Customer>("Customers")
                .EntityType
                .Select()
                .Filter()
                .Expand()
                .Page();

            builder.EntitySet<Product>("Products")
                .EntityType
                .Select()
                .Filter()
                .Expand(SelectExpandType.Automatic);

            builder.EntitySet<ProductModel>("ProductModels")
                .EntityType
                .Select()
                .Expand()
                .Filter();

            builder.EntitySet<SalesOrderDetail>("SalesOrderDetails")
                .EntityType
                .Select()
                .Expand(SelectExpandType.Automatic)
                .Filter();

            builder.EntitySet<ProductCategory>("ProductCategories").EntityType.Select().Expand().Filter();

            builder.EntitySet<Personal>("Personal").EntityType.Select().Expand().Filter().Count();

            return builder.GetEdmModel();


        }
    }
}