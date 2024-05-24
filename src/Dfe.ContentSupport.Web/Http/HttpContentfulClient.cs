using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;

namespace Dfe.ContentSupport.Web.Http
{
    public class HttpContentfulClient : ContentfulClient, IHttpContentfulClient
    {
        public HttpContentfulClient(HttpClient httpClient, ContentfulOptions options) : base(httpClient, options)
        {
        }

        public Task<ContentfulCollection<T>> Query<T>(QueryBuilder<T> queryBuilder, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntries<T>(queryBuilder, cancellationToken);
        }
    }
}
