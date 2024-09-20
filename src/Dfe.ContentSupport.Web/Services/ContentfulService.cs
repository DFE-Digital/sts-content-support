using Contentful.Core;
using Contentful.Core.Search;
using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Services;

public class ContentfulService(IContentfulClient client)
    : IContentfulService
{
    private readonly IContentfulClient _client =
        client ?? throw new ArgumentNullException(nameof(client));

    public async Task<IEnumerable<ContentSupportPage>> GetContentSupportPages(string field,
        string value, CancellationToken cancellationToken = default)
    {
        var builder = QueryBuilder<ContentSupportPage>.New.ContentTypeIs(nameof(ContentSupportPage))
            .FieldEquals($"fields.{field}", value)
            .Include(10);

        var entries = await _client.GetEntries(builder, cancellationToken);

        return entries ?? Enumerable.Empty<ContentSupportPage>();
    }
}