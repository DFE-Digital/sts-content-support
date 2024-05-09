using Dfe.ContentSupport.Web.Models;

namespace Dfe.ContentSupport.Web.Services;
public interface IContentRenderer
{
    string Render(ContentSupportPage page);
}