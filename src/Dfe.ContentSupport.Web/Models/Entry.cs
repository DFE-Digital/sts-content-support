using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class Entry : ContentBase
{
    public RichText RichText { get; set; } = null!;
}