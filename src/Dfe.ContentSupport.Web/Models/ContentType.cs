using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ContentType
{
    public string Id { get; set; } = null!;
    public Sys Sys { get; set; } = null!;
}
