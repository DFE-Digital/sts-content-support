using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ContentSupportPage
{
    public string InternalName { get; init; } = null!;
    public string Slug { get; init; } = null!;

    public List<dynamic> BeforeTitleContent { get; init; } = [];

    public Heading Heading { get; init; } = null!;

    public List<dynamic> Content { get; init; } = [];

    public bool DisplayBackButton { get; init; }
    public bool IsSitemap { get; init; }

    public DateTime? CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; init; }
}
