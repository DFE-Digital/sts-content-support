using System.Xml.Linq;
using Contentful.Core;
using Contentful.Core.Search;
using Dfe.ContentSupport.Web.Models;

namespace Dfe.ContentSupport.Web.Services;

public class ContentfulService(IContentfulClient contentfulClient) : IContentfulService
{
    public async Task<object> GetContent(string slug)
    {
        var builder = QueryBuilder<ContentSupportPage>.New.ContentTypeIs(nameof(ContentSupportPage))
            .FieldEquals($"fields.{nameof(ContentSupportPage.Slug)}", slug);
        var resp = await contentfulClient.GetEntries(builder);
        return resp.FirstOrDefault();
    }

    public async Task<string> GenerateSitemap(string baseUrl)
    {
        var builder = QueryBuilder<ContentSupportPage>.New.ContentTypeIs(nameof(ContentSupportPage))
            .FieldEquals($"fields.{nameof(ContentSupportPage.IsSitemap)}", "true");
        var resp = await contentfulClient.GetEntries(builder);

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