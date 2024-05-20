using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ContentItem
{
    public string NodeType { get; set; } = null!;
    public Data Data { get; set; } = null!;
    public List<ContentItem> Content { get; set; } = [];
    public string Value { get; set; } = null!;
}