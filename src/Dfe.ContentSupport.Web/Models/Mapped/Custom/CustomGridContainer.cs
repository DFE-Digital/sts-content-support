using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Custom;

public class CustomGridContainer(Target target) : CustomComponent(CustomComponentType.GridContainer)
{
    public readonly List<CustomCard> Cards =
        target.Content.Select(card => new CustomCard(card)).ToList();
}