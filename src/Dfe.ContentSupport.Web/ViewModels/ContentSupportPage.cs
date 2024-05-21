using System.Diagnostics.CodeAnalysis;
using Dfe.ContentSupport.Web.Models;

namespace Dfe.ContentSupport.Web.ViewModels;

[ExcludeFromCodeCoverage]
public class ContentSupportPage : ContentBase
{
    public string Slug { get; init; } = null!;

    public List<dynamic> BeforeTitleContent { get; init; } = [];

    public Heading Heading { get; init; } = null!;
    public List<Entry> Content { get; init; } = [];

    public bool DisplayBackButton { get; init; }
    public bool IsSitemap { get; init; }

    public DateTime? CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; init; }
}