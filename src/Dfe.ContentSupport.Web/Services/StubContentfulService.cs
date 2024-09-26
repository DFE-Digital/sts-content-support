using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Dfe.ContentSupport.Web.ViewModels;
using Newtonsoft.Json;

namespace Dfe.ContentSupport.Web.Services;

public class StubContentfulService(HttpClient httpClient, ContentfulOptions options)
    : ContentfulClient(httpClient, options), IContentfulService
{
    public async Task<IEnumerable<ContentSupportPage>> GetContentSupportPages(string field,
        string value, CancellationToken cancellationToken = default)
    {
        var json = await System.IO.File.ReadAllTextAsync("StubData/ContentfulCollection.json",
            cancellationToken);
        var resp = JsonConvert.DeserializeObject<ContentSupportPage>(json);
        return resp == null
            ? new ContentfulCollection<ContentSupportPage>()
            : new ContentfulCollection<ContentSupportPage> { Items = [resp] };
    }
}