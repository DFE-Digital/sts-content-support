namespace Dfe.ContentSupport.Web.Services;

public interface IContentfulService
{
    Task<object> GetContent(string slug);
    Task<string> GenerateSitemap(string baseUrl);
}