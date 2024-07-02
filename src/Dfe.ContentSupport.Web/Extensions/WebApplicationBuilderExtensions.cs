using Contentful.Core.Configuration;
using Dfe.ContentSupport.Data.Context;
using Dfe.ContentSupport.Web.Configuration;
using Dfe.ContentSupport.Web.Http;
using Dfe.ContentSupport.Web.Services;
using Microsoft.EntityFrameworkCore;

using ContentfulOptions = Dfe.ContentSupport.Web.Configuration.ContentfulOptions;

namespace Dfe.ContentSupport.Web.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void InitDependencyInjection(this WebApplicationBuilder app)
    {
        app.Services.Configure<ContentfulOptions>(app.Configuration.GetSection("ContentfulOptions"));

        app.Services.AddDbContext<SubscriberDbContext>(options =>
        {
            var connectionString = app.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });


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