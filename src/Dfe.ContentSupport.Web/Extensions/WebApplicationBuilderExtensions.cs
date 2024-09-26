using Contentful.Core;
using Contentful.Core.Configuration;
using Dfe.ContentSupport.Web.Configuration;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.Services;
using Microsoft.Extensions.Options;

namespace Dfe.ContentSupport.Web.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void InitCsDependencyInjection(this WebApplicationBuilder app)
    {
        app.Services.Configure<TrackingOptions>(app.Configuration.GetSection("tracking"))
            .AddSingleton(sp => sp.GetRequiredService<IOptions<TrackingOptions>>().Value);

        app.Services.Configure<SupportedAssetTypes>(app.Configuration.GetSection("cs:supportedAssetTypes"))
            .AddSingleton(sp => sp.GetRequiredService<IOptions<SupportedAssetTypes>>().Value);

        app.Services.SetupContentfulClient(app);

        app.Services.AddTransient<ICacheService<List<CsPage>>, CsPagesCacheService>();
        app.Services.AddTransient<IModelMapper, ModelMapper>();
        app.Services.AddTransient<IContentService, ContentService>();
        app.Services.AddTransient<ILayoutService, LayoutService>();

        app.Services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.Strict;
            options.ConsentCookieValue = "false";
        });


    }

    public static void SetupContentfulClient(this IServiceCollection services, WebApplicationBuilder app)
    {
        app.Services.Configure<ContentfulOptions>(app.Configuration.GetSection("cs:contentful"))
            .AddSingleton(sp => sp.GetRequiredService<IOptions<ContentfulOptions>>().Value);

        services.AddScoped<IContentfulClient, ContentfulClient>();
        
        if (app.Environment.EnvironmentName.Equals("e2e"))
        {
            services.AddScoped<IContentfulService, StubContentfulService>();
        }
        else
        {
            services.AddScoped<IContentfulService, ContentfulService>();
        }
        
        

        HttpClientPolicyExtensions.AddRetryPolicy(services.AddHttpClient<ContentfulClient>());
    }
}