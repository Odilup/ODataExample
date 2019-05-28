using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataService.Controllers;
using ODataService.Models;

namespace ODataService
{
    public class TopAndSkipController : ProductsController
    {
        // GET
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Top | AllowedQueryOptions.Skip)]
        public new IQueryable<Product> Get()
        {
            return products.AsQueryable();
        }
    }
}