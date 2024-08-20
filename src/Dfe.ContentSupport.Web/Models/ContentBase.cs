using System.Diagnostics.CodeAnalysis;
namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ContentBase : Contentful.Core.Models.Entry<ContentBase>
{
    public string InternalName { get; set; } = null!;

    public string? Title { get; set; } = null;

    public string? Subtitle { get; set; } = null;
}