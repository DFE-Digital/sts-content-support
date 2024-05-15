using Dfe.ContentSupport.Web.Models;

namespace Dfe.ContentSupport.Web.Services;

public interface IContentfulService
{
    Task<ContentSupportPage?> GetContent(string slug);
    Task<string> GenerateSitemap(string baseUrl);
}