using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Standard;

public class EmbeddedAsset(Fields asset, string internalName)
    : RichTextContentItem(RichTextNodeType.EmbeddedAsset, internalName)
{
    public readonly string Uri = asset.File.Url;
    public readonly string Title = asset.Title;
    public readonly string Description = asset.Description;

    public readonly AssetContentType AssetContentType = asset.File.ContentType switch
    {
        "image/jpeg" or "image/png" => AssetContentType.Image,
        "video/mp4" or "video/quicktime" => AssetContentType.Video,
        _ => AssetContentType.Unknown
    };
}