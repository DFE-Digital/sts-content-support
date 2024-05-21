using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Services;

public interface IContentfulService
{
    Task<ContentSupportPage?> GetContent(string slug);
    Task<string> GenerateSitemap(string baseUrl);
}