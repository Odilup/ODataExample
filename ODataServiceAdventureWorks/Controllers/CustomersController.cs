using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODataServiceAdventureWorks.Models;

namespace ODataServiceAdventureWorks.Controllers
{
    public class CustomersController : ODataController
    {
        private AdventureWorksContext _ctx;

        public CustomersController(AdventureWorksContext ctx)
        {
            _ctx = ctx;
        }

        [EnableQuery]
        public IQueryable<Customer> Get()
        {
            return _ctx.Customer;
        }

        [EnableQuery]
        [ODataRoute("Customers({key})")]
        public SingleResult<Customer> GetCustomer([FromODataUri] int key)
        {
            var customer = _ctx.Customer.Where(c => c.CustomerId == key);
            return SingleResult.Create(customer);
        }

        [ODataRoute("Customers({key})/CustomerAddress")]
        public async Task<IActionResult> GetCustomerAddress([FromODataUri] int key)
        {
            var customer = await _ctx.Customer.FindAsync(key).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer.CustomerAddress);
            }
        }
    }
}