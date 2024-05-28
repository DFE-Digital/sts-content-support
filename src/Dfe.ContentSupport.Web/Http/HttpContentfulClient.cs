using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;

namespace Dfe.ContentSupport.Web.Http;

public class HttpContentfulClient(HttpClient httpClient, ContentfulOptions options)
    : ContentfulClient(httpClient, options), IHttpContentfulClient
{
    public Task<ContentfulCollection<T>> Query<T>(QueryBuilder<T> queryBuilder,
        CancellationToken cancellationToken = default)
    {
        return GetEntries(queryBuilder, cancellationToken);
    }
}