using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class Entry : ContentItem
{
    public string JumpIdentifier { get; set; } = null!;
    public ContentItemBase RichText { get; set; } = null!;
}