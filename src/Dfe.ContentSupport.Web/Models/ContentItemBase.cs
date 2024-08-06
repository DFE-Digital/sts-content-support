using Contentful.Core.Models;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ContentItemBase
{
    public string InternalName { get; set; } = null!;
    public string NodeType { get; set; } = null!;
    public Data Data { get; set; } = null!;
    public List<ContentItem> Content { get; set; } = [];
    public ContentfulMetadata Metadata { get; set; } = null!;
}