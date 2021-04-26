using kcs.Blog.Domain.Entities;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace kcs.Blog.Infrastructure.OData
{
    public class OdataModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string routePrefix)
        {
            builder.EntitySet<Article>("Articles");
            builder.EntitySet<Review>("Reviews");
        }
    }
}
