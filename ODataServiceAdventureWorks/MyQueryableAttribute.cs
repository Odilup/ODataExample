using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;

namespace ODataServiceAdventureWorks
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