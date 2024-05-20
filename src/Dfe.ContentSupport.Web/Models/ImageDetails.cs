using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ImageDetails
{
    public int Size { get; set; }
    public ImageSize Image { get; set; } = null!;
}