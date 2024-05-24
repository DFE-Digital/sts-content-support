using Contentful.Core.Configuration;
using Dfe.ContentSupport.Web.Services;
using Microsoft.Extensions.Configuration;

namespace Dfe.ContentSupport.Web.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void InitDependencyInjection(this WebApplicationBuilder app)
    {
        var contentfulOptions = new ContentfulOptions();
        app.Configuration.GetSection("ContentfulOptions").Bind(contentfulOptions);
        app.Services.AddSingleton(contentfulOptions);

        app.Services.AddTransient<IContentfulService, ContentfulService>();
        app.Services.AddTransient<IContentService, ContentService>();
    }
}