namespace Dfe.ContentSupport.Web.Models.Mapped;

public class EmbeddedAsset(Fields asset) : RichTextContentItem(RichTextNodeType.EmbeddedAsset)
{
    public string Uri { get; } = asset.File.Url;
    public string Title { get; } = asset.Title;
    public string Description { get; } = asset.Description;

    public AssetContentType AssetContentType { get; } = asset.File.ContentType switch
    {
        "image/jpeg" or "image/png" => AssetContentType.Image,
        "video/mp4" or "video/quicktime" => AssetContentType.Video,
        _ => AssetContentType.Unknown
    };
}