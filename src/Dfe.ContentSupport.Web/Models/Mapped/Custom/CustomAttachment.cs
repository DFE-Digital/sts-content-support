using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Custom;

public class CustomAttachment(Target target) : CustomComponent(CustomComponentType.Attachment)
{
    public readonly string Uri = target.Asset.File.Url;
    public readonly string ContentType = target.Asset.File.ContentType;
    public readonly string Title = target.Title;
    public readonly long Size = target.Asset.File.Details.Size;
}