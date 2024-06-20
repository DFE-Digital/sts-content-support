using System.Diagnostics.CodeAnalysis;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Custom;

public class CustomAttachment(Target target) : CustomComponent(CustomComponentType.Attachment)
{
    public string Uri { get; init; } = target.Asset.File.Url;
    public string ContentType { get; init; } = target.Asset.File.ContentType;
    public string Title { get; init; } = target.Title;
    public long Size { get; init; } = target.Asset.File.Details.Size;
}