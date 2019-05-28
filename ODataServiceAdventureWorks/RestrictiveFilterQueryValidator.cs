using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;

namespace ODataServiceAdventureWorks
{
    public class RestrictiveFilterQueryValidator : FilterQueryValidator
    {
 
        public override void ValidateSingleValuePropertyAccessNode(SingleValuePropertyAccessNode propertyAccessNode,
            ODataValidationSettings settings)
        {
            if (propertyAccessNode.Source.TypeReference.FullName().Contains("Product") && propertyAccessNode.Property.Name == "Name")
            {
                throw new ODataException("No se puede filtrar por nombre en Products");

            }
            base.ValidateSingleValuePropertyAccessNode(propertyAccessNode, settings);
        }

        public RestrictiveFilterQueryValidator(DefaultQuerySettings defaultQuerySettings) : base(defaultQuerySettings)
        {
        }
    }
}