using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class FileDetails
{
    public string Url { get; set; }
    public ImageDetails Details { get; set; }
    public string Filename { get; set; }
    public string ContentType { get; set; }
}