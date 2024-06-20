using System.Diagnostics.CodeAnalysis;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Models.Mapped.Custom;

public class CustomAccordion(Target target)
    : CustomComponent(CustomComponentType.Accordion, target.InternalName)
{
    public new string InternalName { get; } = target.InternalName;
    public string Title { get; } = target.Title;
    public string SummaryLine { get; } = target.SummaryLine;
    public string Body { get; } = target.Body;

    public List<CustomAccordion> Accordions { get; } =
        target.Content.Select(accordion => new CustomAccordion(accordion)).ToList();
}