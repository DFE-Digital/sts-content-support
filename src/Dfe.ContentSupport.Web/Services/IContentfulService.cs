using Contentful.Core;

namespace Dfe.ContentSupport.Web.Services
{
    public interface IContentfulService
    {
        IContentfulClient ContentfulClient(bool isPreview = false);
    }
}
