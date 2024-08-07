using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models.Mapped;

[ExcludeFromCodeCoverage]
public class CsPage
{
    public Heading Heading { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public bool IsSitemap { get; set; }
    public bool HasCitation { get; set; }
    public bool HasBackToTop { get; set; }
    public List<CsContentItem> Content { get; set; } = null!;
    public DateTime? CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }

    public List<string> Tags { get;set; } = null!;
}