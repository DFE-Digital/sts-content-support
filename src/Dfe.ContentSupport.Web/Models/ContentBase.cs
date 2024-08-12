using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ContentBase : ContentType
{
    public string InternalName { get; set; } = null!;

    public string? Title { get; set; } = null;

    public string? Subtitle { get; set; } = null;
}