namespace Dfe.ContentSupport.Web.Models.Mapped;

public class Hyperlink(string uri) : RichTextContentItem(RichTextNodeType.Hyperlink)
{
    public string Uri { get; init; } = uri;
    public bool IsVimeo { get; init; } = uri.Contains("vimeo.com");
}