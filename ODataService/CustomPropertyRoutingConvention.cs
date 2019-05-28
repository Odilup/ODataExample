using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;

namespace ODataService
{
    public class CustomPropertyRoutingConvention : NavigationSourceRoutingConvention
    {
        public override string SelectAction(RouteContext routeContext, SelectControllerResult controllerResult, IEnumerable<ControllerActionDescriptor> actionDescriptors)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomODataQueryValidator : ODataQueryValidator
    {
        public CustomODataQueryValidator()
        {
        }

        
    }
}
