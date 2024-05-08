namespace Dfe.ContentSupport.Web.Models;

public class Page
{
    public string InternalName { get; init; } = null!;

    public string Slug { get; init; } = null!;

    public string? SectionTitle { get; set; }

    public List<dynamic> BeforeTitleContent { get; init; } = [];

    public bool IsSitemap { get; init; } = false;

    public List<dynamic> Content { get; init; } = [];
}