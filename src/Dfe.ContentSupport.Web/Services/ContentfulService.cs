using Contentful.Core;
using Contentful.Core.Configuration;
using Dfe.ContentSupport.Web.Http;
using System.Net.Http;

namespace Dfe.ContentSupport.Web.Services
{
    public class ContentfulService(ContentfulOptions contentfulOptions, HttpClient httpClient, IHttpContentfulClient httpContentfulClient) : IContentfulService
    {

        public IHttpContentfulClient ContentfulClient(bool isPreview = false)
        {
            contentfulOptions.UsePreviewApi = isPreview;
            return httpContentfulClient;
        }
    }
}
