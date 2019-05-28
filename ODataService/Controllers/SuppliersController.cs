using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODataService.Models;

namespace ODataService.Controllers
{
    public class SuppliersController : ODataController
    {
        private SampleDatabase _database = new SampleDatabase();

        [MyQueryable]
        public IQueryable<Supplier> Get()
        {
            return _database.Suppliers.AsQueryable();
        }
    }
}