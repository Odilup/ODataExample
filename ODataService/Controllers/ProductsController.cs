using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataService.Models;
using SingleResult = Microsoft.AspNet.OData.SingleResult;

namespace ODataService.Controllers
{
    public class ProductsController : ODataController
    {

        private SampleDatabase _database = new SampleDatabase();

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return _database.Products.AsQueryable();
        }

        [ODataRoute("Products({key})")]
        public Product GetProductById([FromODataUri] int key)
        {
            return _database.Products.FirstOrDefault(product => product.ID == key);
        }

        [ODataRoute("Products({key})/Name")]
        public IActionResult GetName([FromODataUri] int key)
        {
            return Ok(_database.Products.FirstOrDefault(product => product.ID == key).Name);
        }

        [ODataRoute("Products({key})/Supplier")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public Microsoft.AspNet.OData.SingleResult<Supplier> GetSupplier([FromODataUri] int key)
        {
            var result = _database.Products.Where(s => s.ID == key).Select(m => m.Supplier).AsQueryable();
            return SingleResult.Create(result);
        }

    }
}