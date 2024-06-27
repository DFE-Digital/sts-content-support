using System.Xml.Linq;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Services;

public class ContentService(IContentfulService contentfulService) : IContentService
{
    public async Task<ContentSupportPage?> GetContent(string slug, bool isPreview = false)
    {
        var resp = await GetContentSupportPages(nameof(ContentSupportPage.Slug), slug, isPreview);
        return resp is not null && resp.Any() ? resp.First() : null;
    }

    public async Task<string> GenerateSitemap(string baseUrl)
    {
        var resp =
            await GetContentSupportPages(nameof(ContentSupportPage.IsSitemap), "true", false);

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

    public async Task<ContentfulCollection<ContentSupportPage>> GetContentSupportPages(
        string field, string value, bool isPreview)
    {
        var builder = QueryBuilder<ContentSupportPage>.New.ContentTypeIs(nameof(ContentSupportPage))
            .FieldEquals($"fields.{field}", value);

        return await contentfulService.ContentfulClient(isPreview).Query(builder);
    }

}