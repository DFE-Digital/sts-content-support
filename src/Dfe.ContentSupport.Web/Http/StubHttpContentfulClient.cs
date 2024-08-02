using Contentful.Core;
using Dfe.ContentSupport.Web.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Newtonsoft.Json;

namespace Dfe.ContentSupport.Web.Http;

public class StubHttpContentfulClient(HttpClient httpClient, CsContentfulOptions options)
    : ContentfulClient(httpClient, options), IHttpContentfulClient
{
    public async Task<ContentfulCollection<T>> Query<T>(QueryBuilder<T> queryBuilder,
        CancellationToken cancellationToken = default) where T : class
    {
        var json = await System.IO.File.ReadAllTextAsync("Http/StubData/ContentfulCollection.json",
            cancellationToken);
        var resp = JsonConvert.DeserializeObject<T>(json);
        return resp == null
            ? new ContentfulCollection<T>()
            : new ContentfulCollection<T> { Items = new[] { resp } };
    }
}