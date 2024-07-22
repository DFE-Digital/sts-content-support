using Dfe.ContentSupport.Web.Configuration;
using Dfe.ContentSupport.Web.Http;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.Services;
using Microsoft.Extensions.Options;

namespace Dfe.ContentSupport.Web.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void InitDependencyInjection(this WebApplicationBuilder app)
    {
        app.Services.Configure<CsContentfulOptions>(app.Configuration.GetSection("Contentful"))
            .AddSingleton(sp => sp.GetRequiredService<IOptions<CsContentfulOptions>>().Value);

        app.Services.Configure<TrackingOptions>(app.Configuration.GetSection("tracking"))
            .AddSingleton(sp => sp.GetRequiredService<IOptions<TrackingOptions>>().Value);

        app.Services
            .AddTransient<ICacheService<List<CsPage>>, CsPagesCacheService>();
        app.Services.AddTransient<IModelMapper, ModelMapper>();
        app.Services.AddTransient<IContentfulService, ContentfulService>();
        app.Services.AddTransient<IContentService, ContentService>();

        app.Services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.Strict;
            options.ConsentCookieValue = "false";
        });

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
