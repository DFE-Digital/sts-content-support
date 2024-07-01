using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class Sys
{
    public string Id { get; set; } = null!;
    public ContentType? ContentType { get; set; } = null!;
}