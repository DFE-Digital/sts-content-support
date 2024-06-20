namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CustomAccordion(Target target) : CustomComponent(CustomComponentType.Accordion)
{
    public string InternalName { get; } = target.InternalName;
    public string Title { get; } = target.Title;
    public string SummaryLine { get; } = target.SummaryLine;
    public string Body { get; } = target.Body;

    public List<CustomAccordion> Accordions { get; } =
        target.Content.Select(accordion => new CustomAccordion(accordion)).ToList();
}