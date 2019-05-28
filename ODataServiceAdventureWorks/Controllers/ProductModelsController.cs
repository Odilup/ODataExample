using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using ODataServiceAdventureWorks.Models;

namespace ODataServiceAdventureWorks.Controllers
{
    public class ProductModelsController : ODataController
    {
        private AdventureWorksContext _ctx;

        public ProductModelsController(AdventureWorksContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<ProductModel> Get()
        {
            return _ctx.ProductModel;
        }

        [EnableQuery]
        [ODataRoute("ProductModels({id})")]
        public SingleResult<ProductModel> Get([FromODataUri] int id)
        {
            var result = _ctx.ProductModel.Where(p => p.ProductModelId == id);
            return SingleResult.Create(result);
        }
    }
}