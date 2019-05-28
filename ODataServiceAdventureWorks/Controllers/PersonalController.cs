using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODataServiceAdventureWorks.Models;

namespace ODataServiceAdventureWorks.Controllers
{
    public class PersonalController : ODataController
    {
        private AdventureWorksContext _ctx;

        public PersonalController(AdventureWorksContext ctx)
        {
            _ctx = ctx;
        }

        [EnableQuery]
        public IQueryable<Personal> Get()
        {
            return _ctx.Personal;
        }

        [HttpPost]
        public void Post([FromBody] Personal personal)
        {
            _ctx.Personal.Add(personal);
            _ctx.SaveChanges();
        }

        public void Delete([FromODataUri] int key)
        {
            var personal = _ctx.Personal.FirstOrDefault(o => o.Id == key);

            if (personal == null) return;

            _ctx.Personal.Remove(personal);
            _ctx.SaveChanges();

        }
    }
}