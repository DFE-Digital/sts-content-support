using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class Heading : ContentBase
{
    public string Title { get; init; } = null!;
    public string Subtitle { get; init; } = null!;
}