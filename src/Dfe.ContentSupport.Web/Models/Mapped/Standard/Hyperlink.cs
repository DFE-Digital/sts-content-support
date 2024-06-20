using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Standard;

public class Hyperlink(string uri) : RichTextContentItem(RichTextNodeType.Hyperlink, string.Empty)
{
    public readonly bool IsVimeo = uri.Contains("vimeo.com");
    public readonly string Uri = uri;
}