using Dfe.ContentSupport.Web.Common;
using Dfe.ContentSupport.Web.Models;
using Dfe.ContentSupport.Web.Models.Mapped.Custom;
using Dfe.ContentSupport.Web.Models.Mapped.Standard;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Tests.Models.Mapped.Custom;

public class CustomAccordionTests
{
    private static ModelMapper GetService() => new();

    private const string ContentId = "CSAccordion";
    private const string InternalName = "Internal Name";
    private const string Title = "Title";
    private const string SummaryLine = "Summary Line";
    private const string Body = "Body";

    private static ContentItem DummyContentItem() => new()
    {
        NodeType = RichTextTags.EmbeddedEntry,
        Data = new Web.Models.Data
        {
            Target = new Target
            {
                InternalName = InternalName,
                Title = Title,
                SummaryLine = SummaryLine,
                Body = Body,
                Sys = new Sys
                {
                    ContentType = new ContentType
                    {
                        Sys = new Sys
                        {
                            Id = ContentId
                        }
                    }
                },
                Content =
                [
                    new Target(),
                    new Target(),
                    new Target()
                ]
            }
        }
    };


    [Fact]
    public void MapCorrectly()
    {
        var testValue = DummyContentItem();

        var sut = GetService();
        var result = sut.MapContent(testValue);
        result.Should().BeAssignableTo<EmbeddedEntry>();
        var entry = (result as EmbeddedEntry)!;

        entry.NodeType.Should().Be(RichTextNodeType.EmbeddedEntry);
        entry.InternalName.Should().Be(InternalName);
        entry.RichText.Should().BeNull();
        entry.CustomComponent.Should().NotBeNull();

        var customComponent = entry.CustomComponent;
        customComponent.Should().BeAssignableTo<CustomAccordion>();
        var accordion = (customComponent as CustomAccordion)!;

        accordion.Type.Should().Be(CustomComponentType.Accordion);
        accordion.InternalName.Should().Be(InternalName);
        accordion.Title.Should().Be(Title);
        accordion.SummaryLine.Should().Be(SummaryLine);
        accordion.Body.Should().Be(Body);
        accordion.Accordions.Count.Should().Be(3);
    }
}