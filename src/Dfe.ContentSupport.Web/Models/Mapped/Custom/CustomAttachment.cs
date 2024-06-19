namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CustomAttachment(Target target) : CustomComponent(CustomComponentType.Attachment)
{
    public string Uri { get; init; } = target.Asset.File.Url;
    public string ContentType { get; init; } = target.Asset.File.ContentType;
    public string Title { get; init; } = target.Title;
    public long Size { get; init; } = target.Asset.File.Details.Size;
}