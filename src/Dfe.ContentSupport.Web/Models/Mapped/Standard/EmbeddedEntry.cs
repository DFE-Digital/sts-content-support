using Dfe.ContentSupport.Web.Models.Mapped.Custom;
using Dfe.ContentSupport.Web.Models.Mapped.Types;
using Dfe.ContentSupport.Web.Services;

namespace Dfe.ContentSupport.Web.Models.Mapped.Standard;

public class EmbeddedEntry(Target target)
    : RichTextContentItem(RichTextNodeType.EmbeddedEntry, target.InternalName)
{
    public readonly string JumpIdentifier = target.JumpIdentifier;

    public readonly RichTextContentItem? RichText =
        ContentSupportMapperService.MapRichTextContent(target.RichText);

    public readonly CustomComponent? CustomComponent =
        ContentSupportMapperService.GenerateCustomComponent(target);
}