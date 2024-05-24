using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class Entry : ContentBase
{
    public ContentItemBase RichText { get; set; } = null!;
}