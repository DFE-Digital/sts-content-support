using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Custom;

public class CustomGridContainer(Target target) : CustomComponent(CustomComponentType.GridContainer)
{
    public List<CustomCard> Cards { get; } =
        target.Content.Select(card => new CustomCard(card)).ToList();
}