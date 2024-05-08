namespace Dfe.ContentSupport.Web.Models;

public class ContentSupportPage
{
    public string InternalName { get; init; } = null!;
    public string Slug { get; init; } = null!;

    public List<dynamic> BeforeTitleContent { get; init; } = [];

    public Title Title { get; init; } = null!;

    public List<dynamic> Content { get; init; } = [];

    public bool DisplayBackButton { get; init; }

    public bool IsSitemap { get; init; }

    public DateTime? CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; init; }
}