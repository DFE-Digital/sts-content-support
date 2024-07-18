using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Common;

public static class Utilities
{
    public static string[] ImageSupportedTypes = [];
    public static string[] VideoSupportedTypes = [];
    
    public static AssetContentType ConvertToAssetContentType(string str)
    {
        if (ImageSupportedTypes.Contains(str)) return AssetContentType.Image;
        if (VideoSupportedTypes.Contains(str)) return AssetContentType.Video;
        return AssetContentType.Unknown;
    }
}