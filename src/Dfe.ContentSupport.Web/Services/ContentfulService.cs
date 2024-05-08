using Contentful.Core;
using Dfe.ContentSupport.Web.Models;

namespace Dfe.ContentSupport.Web.Services;

public class ContentfulService(IContentfulClient contentfulClient) : IContentfulService
{
    public async Task<object> GetContent()
    {
        return await contentfulClient.GetEntries<Page>();
    }
}