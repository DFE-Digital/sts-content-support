using Dfe.ContentSupport.Web.Configuration;
using Dfe.ContentSupport.Web.Http;

namespace Dfe.ContentSupport.Web.Services
{
    public class ContentfulService(CsContentfulOptions contentfulOptions, IHttpContentfulClient httpContentfulClient) : IContentfulService
    {

        public IHttpContentfulClient ContentfulClient(bool isPreview = false)
        {
            contentfulOptions.UsePreviewApi = isPreview;
            return httpContentfulClient;
        }
    }
}
