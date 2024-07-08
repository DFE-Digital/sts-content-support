using Dfe.ContentSupport.Web.Configuration;
using Dfe.ContentSupport.Web.Http;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.Services;

namespace Dfe.ContentSupport.Web.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void InitDependencyInjection(this WebApplicationBuilder app)
    {
        var contentfulOptions = new CsContentfulOptions();
        app.Configuration.GetSection("Contentful").Bind(contentfulOptions);
        app.Services.AddSingleton(contentfulOptions);




        app.Services
            .AddTransient<ICacheService<List<CsPage>>, CsPagesCacheService>();
        app.Services.AddTransient<IContentfulService, ContentfulService>();
        app.Services.AddTransient<IContentService, ContentService>();

        if (app.Environment.EnvironmentName.Equals("e2e"))
        {
            app.Services.AddTransient<IHttpContentfulClient, StubHttpContentfulClient>();
        }
        else
        {
            app.Services.AddTransient<IHttpContentfulClient, HttpContentfulClient>();
        }
    }
}