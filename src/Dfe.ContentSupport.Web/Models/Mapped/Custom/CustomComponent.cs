using System.Diagnostics.CodeAnalysis;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Custom;

public class CustomComponent(CustomComponentType type, string internalName = "")
    : CsContentItem(internalName)
{
    public CustomComponentType Type { get; } = type;
}