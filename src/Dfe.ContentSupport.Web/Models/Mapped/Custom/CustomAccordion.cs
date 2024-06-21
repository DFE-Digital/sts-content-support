using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Custom;

public class CustomAccordion(Target target)
    : CustomComponent(CustomComponentType.Accordion, target.InternalName)
{
    public readonly List<CustomAccordion> Accordions =
        target.Content.Select(accordion => new CustomAccordion(accordion)).ToList();

    public readonly string Body = target.Body;
    public readonly string SummaryLine = target.SummaryLine;
    public readonly string Title = target.Title;
}