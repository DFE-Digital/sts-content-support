using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class Target : ContentBase
{
    public Fields Fields { get; set; } = null!;
}