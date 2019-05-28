using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.AspNetCore.Http;

namespace ODataService
{
    public class MyQueryableAttribute : EnableQueryAttribute
    {
        public override void ValidateQuery(HttpRequest request, ODataQueryOptions queryOptions)
        {
            if (queryOptions.Filter != null)
            {
                queryOptions.Filter.Validator = new RestrictiveFilterQueryValidator(queryOptions.Context.DefaultQuerySettings);
            }


            base.ValidateQuery(request, queryOptions);
        }
    }
}