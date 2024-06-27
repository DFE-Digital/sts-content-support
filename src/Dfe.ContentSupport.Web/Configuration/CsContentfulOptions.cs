using Contentful.Core.Configuration;

namespace Dfe.ContentSupport.Web.Configuration;

public class CsContentfulOptions : ContentfulOptions
{
    public int IncludeDepth { get; set; } = 10;
}