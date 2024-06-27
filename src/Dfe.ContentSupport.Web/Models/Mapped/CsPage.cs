using Dfe.ContentSupport.Web.Common;
using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CsPage(ContentSupportPage contentfulPage)
{
    public readonly List<CsContentItem> Content =
        Utilities.MapEntriesToContent(contentfulPage.Content);

    public readonly Heading Heading = contentfulPage.Heading;
    public readonly string Slug = contentfulPage.Slug;
    public readonly bool IsSitemap = contentfulPage.IsSitemap;
}