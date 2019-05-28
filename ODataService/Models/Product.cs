using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Query;

namespace ODataService.Models
{
    [Page(PageSize = 2)]
    [Count(Disabled = true)]
    [Expand(ExpandType = SelectExpandType.Automatic)]
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public ProductSize Size { get; set; }
    }
}