using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Newtonsoft.Json;

namespace Dfe.ContentSupport.Web.Http
{
    public class StubHttpContentfulClient : ContentfulClient, IHttpContentfulClient
    {
        public StubHttpContentfulClient(HttpClient httpClient, ContentfulOptions options) : base(httpClient, options)
        {
        }

        public async Task<ContentfulCollection<T>> Query<T>(QueryBuilder<T> queryBuilder, CancellationToken cancellationToken = default(CancellationToken))
        {
            var json = System.IO.File.ReadAllText("MockData/mockContent.json");
            var resp = JsonConvert.DeserializeObject<ContentfulCollection<T>>(json);
            return await Task.FromResult<ContentfulCollection<T>>(resp);
        }

    }
}
