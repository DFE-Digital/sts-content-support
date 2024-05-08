using Dfe.ContentSupport.Web.Services;

namespace Dfe.ContentSupport.Web.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void InitDependencyInjection(this WebApplicationBuilder app)
    {
        app.Services.AddTransient<IContentfulService, ContentfulService>();
    }
}