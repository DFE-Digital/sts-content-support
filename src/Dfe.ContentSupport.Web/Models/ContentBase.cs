using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ContentBase
{
    public string Id { get; set; } = null!;
    public string InternalName { get; set; } = null!;
}
