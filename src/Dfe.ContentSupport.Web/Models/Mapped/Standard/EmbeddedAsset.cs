using Dfe.ContentSupport.Web.Common;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Standard;

public class EmbeddedAsset(Fields asset, string internalName)
    : RichTextContentItem(RichTextNodeType.EmbeddedAsset, internalName)
{
    public readonly AssetContentType AssetContentType =
        Utilities.ConvertToAssetContentType(asset.File.ContentType);

    public readonly string Description = asset.Description;
    public readonly string Title = asset.Title;
    public readonly string Uri = asset.File.Url;
}