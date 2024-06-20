using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped;

public class RichTextContentItem(RichTextNodeType nodeType, string internalName)
    : CsContentItem(internalName)
{
    public RichTextNodeType NodeType { get; } = nodeType;
    public string Value { get; set; } = null!;
    public List<RichTextContentItem> Content { get; set; } = [];
}