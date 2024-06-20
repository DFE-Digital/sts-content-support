using System.Diagnostics.CodeAnalysis;
using Dfe.ContentSupport.Web.Models.Mapped.Custom;
using Dfe.ContentSupport.Web.Models.Mapped.Types;
using Dfe.ContentSupport.Web.Services;

namespace Dfe.ContentSupport.Web.Models.Mapped.Standard;

public class EmbeddedEntry(Target target)
    : RichTextContentItem(RichTextNodeType.EmbeddedEntry, target.InternalName)
{
    public string JumpIdentifier { get; } = target.JumpIdentifier;

    public RichTextContentItem? RichText { get; } =
        ContentSupportMapperService.MapRichTextContent(target.RichText);

    public CustomComponent? CustomComponent { get; } =
        ContentSupportMapperService.GenerateCustomComponent(target);
}