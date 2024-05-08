namespace Dfe.ContentSupport.Web.Services;

public interface IContentfulService
{
    Task<object> GetContent();
}