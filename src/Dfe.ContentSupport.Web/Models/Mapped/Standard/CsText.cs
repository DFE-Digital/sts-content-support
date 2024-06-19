namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CsText(ContentItem contentItem) : RichTextContentItem(RichTextNodeType.Text)
{
    public bool IsBold { get; } = contentItem.Marks.Any(mark => mark.Type == "bold");
}