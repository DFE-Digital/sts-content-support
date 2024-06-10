using Contentful.Core;
using Dfe.ContentSupport.Web.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;

namespace Dfe.ContentSupport.Web.Http;

public class HttpContentfulClient(HttpClient httpClient, CsContentfulOptions options)
    : ContentfulClient(httpClient, options), IHttpContentfulClient
{
    public Task<ContentfulCollection<T>> Query<T>(QueryBuilder<T> queryBuilder,
        CancellationToken cancellationToken = default)
    {
        if (options.IncludeDepth != 0)
        {
            queryBuilder = queryBuilder.Include(options.IncludeDepth);
        }

        return GetEntries(queryBuilder, cancellationToken);
    }
}