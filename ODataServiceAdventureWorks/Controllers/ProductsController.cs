using System.Linq;
using Microsoft.AspNet.OData;
using ODataServiceAdventureWorks.Models;

namespace ODataServiceAdventureWorks.Controllers
{

    public class ProductsController : ODataController
    {
        private AdventureWorksContext _ctx;

        public ProductsController(AdventureWorksContext ctx)
        {
            _ctx = ctx;
        }

        [EnableQuery(PageSize = 5)]
        public IQueryable<Product> Get()
        {
            return _ctx.Product;
        }


    }
}