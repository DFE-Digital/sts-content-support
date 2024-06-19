using Dfe.ContentSupport.Web.Services;

namespace Dfe.ContentSupport.Web.Models.Mapped;

public class EmbeddedEntry(Target target) : RichTextContentItem(RichTextNodeType.EmbeddedEntry)
{
    public string JumpIdentifier { get; } = target.JumpIdentifier;

    public RichTextContentItem? RichText { get; } =
        ContentSupportMapperService.MapRichTextContent(target.RichText);

    public CustomComponent? CustomComponent { get; } =
        ContentSupportMapperService.GenerateCustomComponent(target);
}