using System.Diagnostics.CodeAnalysis;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Newtonsoft.Json;

namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class Target : Entry
{
    public Fields Fields { get; set; } = null!;
    public Sys Sys { get; set; } = null!;
    public string Title { get; set; } = null!;

    [JsonConverter(typeof(AssetJsonConverter))]
    public Asset Asset { get; set; } = null!;
    public ContentType ContentType { get; set; } = null!;
    public string SummaryLine { get; set; } = null!;
    public string Body { get; set; } = null!;
}
