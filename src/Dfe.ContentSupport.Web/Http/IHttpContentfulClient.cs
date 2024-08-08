using Contentful.Core.Models;
using Contentful.Core.Search;

namespace Dfe.ContentSupport.Web.Http;

public interface IHttpContentfulClient
{
    Task<ContentfulCollection<T>> Query<T>(QueryBuilder<T> queryBuilder,
        CancellationToken cancellationToken = default) where T : class;
}