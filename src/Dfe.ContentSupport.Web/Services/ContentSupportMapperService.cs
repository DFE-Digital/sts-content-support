using Dfe.ContentSupport.Web.Common;
using Dfe.ContentSupport.Web.Models;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.ViewModels;

namespace Dfe.ContentSupport.Web.Services;

public class ContentSupportMapperService
{
    public CsPage? Map(ContentSupportPage? contentfulPage)
    {
        if (contentfulPage is null) return null;
        var csPage = new CsPage
        {
            IsSitemap = contentfulPage.IsSitemap,
            Heading = contentfulPage.Heading,
            Content = MapContent(contentfulPage.Content)
        };

        return csPage;
    }

    public List<CsContentItem> MapContent(List<Entry> entries)
    {
        var items = new List<CsContentItem>();


        foreach (var entry in entries) items.Add(MapContentItem(entry));

        return items;
    }

    private CsContentItem MapContentItem(Entry entry)
    {
        CsContentItem item;
        if (entry.RichText is not null)
            item = MapRichTextContent(entry.RichText)!;
        else
            item = new CsContentItem();

        item.InternalName = entry.InternalName;
        return item;
    }


    public static RichTextContentItem? MapRichTextContent(ContentItemBase? richText)
    {
        if (richText is null) return null;
        var content = MapRichTextNodes(richText.Content);

        return new RichTextContentItem(Utilities.ConvertToRichTextNodeType(richText.NodeType))
        {
            Content = content
        };
    }

    private static List<RichTextContentItem> MapRichTextNodes(List<ContentItem> nodes)
    {
        var items = new List<RichTextContentItem>();

        foreach (var node in nodes)
        {
            var item = MapContent(node);
            if (item is not null)
                items.Add(item);
            else
                Console.WriteLine(node.NodeType);
        }

        return items;
    }

    private static RichTextContentItem? MapContent(ContentItem contentItem)
    {
        RichTextContentItem? item;
        var nodeType = Utilities.ConvertToRichTextNodeType(contentItem.NodeType);
        switch (nodeType)
        {
            case RichTextNodeType.Text:
                item = new CsText(contentItem);
                break;
            case RichTextNodeType.Heading2:
            case RichTextNodeType.Heading3:
            case RichTextNodeType.Heading4:
            case RichTextNodeType.Heading5:
            case RichTextNodeType.Heading6:
                item = new CsHeading(contentItem);
                break;
            case RichTextNodeType.Hyperlink:
                item = new Hyperlink(contentItem.Data.Uri.ToString());
                break;
            case RichTextNodeType.EmbeddedAsset:
                item = new EmbeddedAsset(contentItem.Data.Target.Fields);
                break;
            case RichTextNodeType.EmbeddedEntry:
                item = new EmbeddedEntry(contentItem.Data.Target);
                break;
            case RichTextNodeType.Paragraph:
            case RichTextNodeType.UnorderedList:
            case RichTextNodeType.OrderedList:
            case RichTextNodeType.ListItem:
            case RichTextNodeType.Table:
            case RichTextNodeType.TableRow:
            case RichTextNodeType.TableHeaderCell:
            case RichTextNodeType.TableCell:
            case RichTextNodeType.Hr:
                item = new RichTextContentItem(nodeType);
                break;
            case RichTextNodeType.Document or RichTextNodeType.Unknown:
            default:
                throw new ArgumentOutOfRangeException(contentItem.NodeType);
        }

        if (item is not null)
        {
            item.Content = MapRichTextNodes(contentItem.Content);
            item.Value = contentItem.Value;
        }

        return item;
    }

    public static CustomComponent? GenerateCustomComponent(Target target)
    {
        var contentType = target.Sys.ContentType?.Sys.Id;
        if (contentType is null) return null;
        return contentType switch
        {
            "CSAccordion" => null, //TODO add accordion support
            "Attachment" => new CustomAttachment(target),
            "csCard" => new CustomCard(target),
            "GridContainer" => new CustomGridContainer(target),
            _ => null
        };
    }
}