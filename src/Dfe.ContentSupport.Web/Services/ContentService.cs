using System.Xml.Linq;
using Contentful.Core.Search;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Services;

public class ContentService(IContentfulService contentfulService) : IContentService
{
    public async Task<CsPage?> GetContent(string slug, bool isPreview = false)
    {
        var resp = await GetContentSupportPages(nameof(ContentSupportPage.Slug), slug, isPreview);
        return resp is not null && resp.Count != 0 ? resp.First() : null;
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

    public async Task<List<CsPage>> GetCsPages()
    {
        var pages =
            await GetContentSupportPages(nameof(ContentSupportPage.IsSitemap), "true", true);
        return pages.ToList();
    }

    private async Task<List<CsPage>> GetContentSupportPages(
        string field, string value, bool isPreview)
    {
        var builder = QueryBuilder<ContentSupportPage>.New.ContentTypeIs(nameof(ContentSupportPage))
            .FieldEquals($"fields.{field}", value);
        var result = await contentfulService.ContentfulClient(isPreview).Query(builder);
        return result.Select(page => new CsPage(page)).ToList();
    }
}