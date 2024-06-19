namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CustomGridContainer(Target target) : CustomComponent(CustomComponentType.GridContainer)
{
    public List<CustomCard> Cards { get; } =
        target.Content.Select(card => new CustomCard(card)).ToList();
}