using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ContentBase
{
    public string InternalName { get; set; } = null!;
}