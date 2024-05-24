using Contentful.Core;
using Contentful.Core.Configuration;
using Dfe.ContentSupport.Web.Http;
using System.Net.Http;

namespace Dfe.ContentSupport.Web.Services
{
    public class ContentfulService(ContentfulOptions contentfulOptions, HttpClient httpClient) : IContentfulService
    {

        public IHttpContentfulClient ContentfulClient(bool isPreview = false)
        {
            var options = new ContentfulOptions
            {
                UsePreviewApi = isPreview,
                DeliveryApiKey = contentfulOptions.DeliveryApiKey,
                Environment = contentfulOptions.Environment,
                ManagementApiKey = contentfulOptions.ManagementApiKey,
                PreviewApiKey = contentfulOptions.PreviewApiKey,
                SpaceId = contentfulOptions.SpaceId,
            };

            return new HttpContentfulClient(httpClient, options);

        }
    }
}
