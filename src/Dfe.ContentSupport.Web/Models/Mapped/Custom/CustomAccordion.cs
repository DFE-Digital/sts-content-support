namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CustomAccordion(Target target): CustomComponent(CustomComponentType.Accordion)
{
    public string Title { get; set; } = null!;
    public string SummaryLine { get; set; } = null!;
    public string Body { get; set; } = null!;
}