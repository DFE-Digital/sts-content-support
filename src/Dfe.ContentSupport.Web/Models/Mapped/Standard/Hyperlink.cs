using System.Diagnostics.CodeAnalysis;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Standard;

public class Hyperlink(string uri) : RichTextContentItem(RichTextNodeType.Hyperlink, string.Empty)
{
    public string Uri { get; init; } = uri;
    public bool IsVimeo { get; init; } = uri.Contains("vimeo.com");
}