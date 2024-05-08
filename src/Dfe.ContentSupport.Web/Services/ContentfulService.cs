

using Contentful.Core;
using Contentful.Core.Search;
using Dfe.ContentSupport.Web.Exceptions;
using Dfe.ContentSupport.Web.Models;
using Microsoft.Extensions.Hosting;
using System.Security.Policy;
using System.Xml.Linq;

public class ContentfulService : IContentfulService
{

    private readonly IContentfulClient _contentfulClient;

    public ContentfulService(IContentfulClient contentfulClient)
    {
        _contentfulClient = contentfulClient;
    }


    public async Task<object> GetContent(string slug)
    {
        var builder = QueryBuilder<ContentSupportPage>.New.ContentTypeIs("contentSupportPage").FieldEquals("fields.slug", slug);
        var resp = await _contentfulClient.GetEntries(builder);
        return resp.FirstOrDefault();

    }

    public async Task<string> GenerateSitemap(string baseUrl)
    {
        var builder = QueryBuilder<ContentSupportPage>.New.ContentTypeIs("contentSupportPage").FieldEquals("fields.isSitemap", "true");
        var resp = await _contentfulClient.GetEntries(builder);

        XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
        var sitemap = new XDocument(
            new XDeclaration("1.0", "UTF-8", null),
            new XElement(xmlns + "urlset", new XAttribute("xmlns", xmlns),
                from url in resp
                select
                    new XElement(xmlns + "url",
                    new XElement(xmlns + "loc", $"{baseUrl}{url.Slug}"), 
                    new XElement(xmlns + "changefreq", "yearly") 
                )
            )
        );

        return sitemap.ToString();
    }

}