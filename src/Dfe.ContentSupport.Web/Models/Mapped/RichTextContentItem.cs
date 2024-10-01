using Dfe.ContentSupport.Web.Models.Mapped.Types;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models.Mapped;

[ExcludeFromCodeCoverage]
public class RichTextContentItem : CsContentItem
{
    public List<RichTextContentItem> Content { get; set; } = [];
    public RichTextNodeType NodeType { get; set; } = RichTextNodeType.Unknown;
    public string? Value { get; set; } = null;
    public List<string> Tags { get; set; } = [];

    public virtual bool HaveNoContent => Content.Count == 0 || Content.TrueForAll(content => content.IsEmptyContent);
    public virtual bool IsEmptyContent => HaveNoContent && string.IsNullOrEmpty(Value);
}