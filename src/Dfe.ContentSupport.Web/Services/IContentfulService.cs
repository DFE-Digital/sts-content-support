using Dfe.ContentSupport.Web.Http;

namespace Dfe.ContentSupport.Web.Services
{
    public interface IContentfulService
    {
        IHttpContentfulClient ContentfulClient(bool isPreview = false);
    }
}
