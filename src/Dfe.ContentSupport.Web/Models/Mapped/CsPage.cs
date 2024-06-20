using Dfe.ContentSupport.Web.Services;
using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CsPage(ContentSupportPage contentfulPage)
{
    public bool IsSitemap { get; init; } = contentfulPage.IsSitemap;
    public Heading Heading { get; init; } = contentfulPage.Heading;

    public List<CsContentItem> Content { get; init; } =
        ContentSupportMapperService.MapContent(contentfulPage.Content);
}