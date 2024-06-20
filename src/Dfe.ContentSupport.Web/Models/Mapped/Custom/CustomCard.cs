using System.Diagnostics.CodeAnalysis;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Custom;

public class CustomCard(Target target) : CustomComponent(CustomComponentType.Card)
{
    public string Title { get; init; } = target.Title;
    public string Description { get; init; } = target.Description;
    public string Meta { get; init; } = target.Meta;
    public string ImageAlt { get; init; } = target.ImageAlt;
    public string Uri { get; init; } = target.Uri;
    public string ImageUri { get; init; } = target.Image.Fields.File.Url;
}