using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Custom;

public class CustomCard(Target target) : CustomComponent(CustomComponentType.Card)
{
    public readonly string Title = target.Title;
    public readonly string Description = target.Description;
    public readonly string Meta = target.Meta;
    public readonly string ImageAlt = target.ImageAlt;
    public readonly string Uri = target.Uri;
    public readonly string ImageUri = target.Image.Fields.File.Url;
}