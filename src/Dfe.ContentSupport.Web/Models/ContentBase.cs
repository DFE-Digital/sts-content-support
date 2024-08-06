using System.Diagnostics.CodeAnalysis;
namespace Dfe.ContentSupport.Web.Models;

[ExcludeFromCodeCoverage]
public class ContentBase : Contentful.Core.Models.Entry<ContentBase>
{
    public string InternalName { get; set; } = null!;

}