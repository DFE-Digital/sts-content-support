using Dfe.ContentSupport.Web.Common;
using Dfe.ContentSupport.Web.Models.Mapped.Custom;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Standard;

public class EmbeddedEntry(Target target)
    : RichTextContentItem(RichTextNodeType.Unknown, target.InternalName)
{
    public readonly CustomComponent? CustomComponent =
        Utilities.GenerateCustomComponent(target);

    public readonly string JumpIdentifier = target.JumpIdentifier;

    public readonly RichTextContentItem? RichText =
        Utilities.MapRichTextContent(target.RichText);
}