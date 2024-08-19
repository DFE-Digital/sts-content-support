using Contentful.Core;
using Dfe.ContentSupport.Web.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;

namespace Dfe.ContentSupport.Web.Http;

public class HttpContentfulClient(HttpClient httpClient, CsContentfulOptions options)
    : ContentfulClient(httpClient, options), IHttpContentfulClient
{
    public async Task<ContentfulCollection<T>> Query<T>(QueryBuilder<T> queryBuilder,
        CancellationToken cancellationToken = default) where T : class
    {
        queryBuilder = queryBuilder.Include(options.IncludeDepth);

        for (int attempt = 1; attempt <= options.RetryAttempts; attempt++)
        {
            try
            {
                return await GetEntries(queryBuilder, cancellationToken);
            }
            catch (Exception)
            {
                if (attempt == options.RetryAttempts)
                {
                    throw;
                }
            }
        }

        return default!;
    }
}