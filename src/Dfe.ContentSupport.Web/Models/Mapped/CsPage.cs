namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CsPage
{
    public bool IsSitemap { get; init; }
    public Heading Heading { get; init; }
    public List<CsContentItem> Content { get; init; }
}

public class CsContentItem
{
    public string InternalName { get; set; }
}

public class RichTextContentItem(RichTextNodeType nodeType)
    : CsContentItem
{
    public string Value { get; set; } = null!;
    public RichTextNodeType NodeType { get; } = nodeType;
    public List<RichTextContentItem> Content { get; set; } = [];
}