using System.Diagnostics.CodeAnalysis;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Standard;

public class CsText(ContentItem contentItem) : RichTextContentItem(RichTextNodeType.Text,contentItem.InternalName)
{
    public bool IsBold { get; } = contentItem.Marks.Any(mark => mark.Type == "bold");
}