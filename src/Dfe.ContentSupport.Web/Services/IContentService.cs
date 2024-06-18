using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Services;

public interface IContentService
{
    Task<ContentSupportPage?> GetContent(string slug, bool isPreview);
    Task<string> GenerateSitemap(string baseUrl);
}