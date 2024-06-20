using Dfe.ContentSupport.Web.Services;
using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CsPage(ContentSupportPage contentfulPage)
{
    public List<CsContentItem> Content =
        ContentSupportMapperService.MapContent(contentfulPage.Content);

    public Heading Heading = contentfulPage.Heading;
    public bool IsSitemap = contentfulPage.IsSitemap;
}