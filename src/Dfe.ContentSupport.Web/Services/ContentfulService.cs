

using Contentful.Core;
using Dfe.ContentSupport.Web.Models;

public class ContentfulService : IContentfulService
{

    private readonly IContentfulClient _contentfulClient;

    public ContentfulService(IContentfulClient contentfulClient)
    {
        _contentfulClient = contentfulClient;
    }
    public async Task<object> GetContent()
    {
        return await _contentfulClient.GetEntries<Page>();
    }
}