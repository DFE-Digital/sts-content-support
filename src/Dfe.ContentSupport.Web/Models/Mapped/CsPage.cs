using Dfe.ContentSupport.Web.Services;
using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CsPage(ContentSupportPage contentfulPage)
{
    public readonly List<CsContentItem> Content =
        ContentSupportMapperService.MapContent(contentfulPage.Content);

    public readonly Heading Heading = contentfulPage.Heading;
    public readonly bool IsSitemap = contentfulPage.IsSitemap;
}