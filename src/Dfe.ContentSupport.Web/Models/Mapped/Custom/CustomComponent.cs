namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CustomComponent(CustomComponentType type)
{
    public CustomComponentType Type { get; } = type;
}