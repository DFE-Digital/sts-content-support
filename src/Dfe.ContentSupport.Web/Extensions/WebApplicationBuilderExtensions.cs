using Contentful.Core;
using Contentful.Core.Configuration;
using Dfe.ContentSupport.Web.Http;
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

        if (app.Environment.Equals("e2e"))
        {
            app.Services.AddTransient<IHttpContentfulClient, StubHttpContentfulClient>();
        }
        else
        {
            app.Services.AddTransient<IHttpContentfulClient, HttpContentfulClient>();
        }


    }
}