
using Microsoft.AspNet.OData.Builder;
using Microsoft.Data.Edm.Library;
using Microsoft.OData.Edm;
using ODataService.Models;

namespace ODataService
{
    public class NonConventionModelBuilder
    {
        public static IEdmModel GetModel()
        {
            var builder = new ODataModelBuilder();

            var product = builder.EntityType<Product>();
            product.HasKey(c => c.ID);
            product.ContainsRequired(c => c.Supplier);

            product.Property(c => c.Name);
            product.Property(c => c.SupplierId);

            product.Expand()
                .Count()
                .Select()
                .Filter();

            var supplier = builder.EntityType<Supplier>();
            supplier.HasKey(c => c.Id);
            supplier.HasMany(c => c.Products);
            supplier.Property(c => c.Name);
            supplier.Expand()
                .Count()
                .Select()
                .Filter();


            builder.EntitySet<Product>("Products");
            builder.EntitySet<Supplier>("Suppliers");

            builder.EnumType<ProductSize>();

            return builder.GetEdmModel();
        }
    }
}