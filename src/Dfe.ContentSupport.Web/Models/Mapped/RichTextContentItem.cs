using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped;

public class RichTextContentItem(RichTextNodeType nodeType, string internalName)
    : CsContentItem(internalName)
{
    public List<RichTextContentItem> Content = [];
    public RichTextNodeType NodeType = nodeType;
    public string Value = null!;
}