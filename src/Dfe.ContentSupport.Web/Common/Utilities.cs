using Dfe.ContentSupport.Web.Models;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.Models.Mapped.Custom;
using Dfe.ContentSupport.Web.Models.Mapped.Standard;
using Dfe.ContentSupport.Web.Models.Mapped.Types;

namespace Dfe.ContentSupport.Web.Common;

public static class Utilities
{
    public static RichTextNodeType ConvertToRichTextNodeType(string str)
    {
        return str switch
        {
            RichTextTags.Document => RichTextNodeType.Document,
            RichTextTags.Paragraph => RichTextNodeType.Paragraph,
            RichTextTags.Heading2 => RichTextNodeType.Heading2,
            RichTextTags.Heading3 => RichTextNodeType.Heading3,
            RichTextTags.Heading4 => RichTextNodeType.Heading4,
            RichTextTags.Heading5 => RichTextNodeType.Heading5,
            RichTextTags.Heading6 => RichTextNodeType.Heading6,
            RichTextTags.UnorderedList => RichTextNodeType.UnorderedList,
            RichTextTags.OrderedList => RichTextNodeType.OrderedList,
            RichTextTags.ListItem => RichTextNodeType.ListItem,
            RichTextTags.Hyperlink => RichTextNodeType.Hyperlink,
            RichTextTags.Table => RichTextNodeType.Table,
            RichTextTags.TableRow => RichTextNodeType.TableRow,
            RichTextTags.TableHeaderCell => RichTextNodeType.TableHeaderCell,
            RichTextTags.TableCell => RichTextNodeType.TableCell,
            RichTextTags.Hr => RichTextNodeType.Hr,
            RichTextTags.EmbeddedAsset => RichTextNodeType.EmbeddedAsset,
            RichTextTags.Text => RichTextNodeType.Text,
            RichTextTags.EmbeddedEntry => RichTextNodeType.EmbeddedEntry,
            RichTextTags.EmbeddedEntryInline => RichTextNodeType.EmbeddedEntry,
            _ => RichTextNodeType.Unknown
        };
    }

    public static List<CsContentItem> MapEntriesToContent(List<Entry> entries)
    {
        return entries.Select(ConvertEntryToContentItem).ToList();
    }

    public static RichTextContentItem? MapRichTextContent(ContentItemBase? richText)
    {
        if (richText is null) return null;
        return new RichTextContentItem(ConvertToRichTextNodeType(richText.NodeType),
            richText.InternalName) { Content = MapRichTextNodes(richText.Content) };
    }

    private static CsContentItem ConvertEntryToContentItem(Entry entry) =>
        entry.RichText is not null
            ? MapRichTextContent(entry.RichText)!
            : new CsContentItem(entry.InternalName);

    public static CustomComponent? GenerateCustomComponent(Target target)
    {
        var contentType = target.Sys.ContentType?.Sys.Id;
        if (contentType is null) return null;
        return contentType switch
        {
            "CSAccordion" => new CustomAccordion(target),
            "Attachment" => new CustomAttachment(target),
            "csCard" => new CustomCard(target),
            "GridContainer" => new CustomGridContainer(target),
            _ => null
        };
    }

    private static List<RichTextContentItem> MapRichTextNodes(List<ContentItem> nodes)
    {
        return (from node in nodes
                let item = MapContent(node)
                select item ?? new RichTextContentItem(RichTextNodeType.Unknown, node.InternalName))
            .ToList();
    }

    private static RichTextContentItem? MapContent(ContentItem contentItem)
    {
        RichTextContentItem? item;
        var nodeType = ConvertToRichTextNodeType(contentItem.NodeType);
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
                item = new EmbeddedAsset(contentItem.Data.Target.Fields, contentItem.InternalName);
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
                item = new RichTextContentItem(nodeType, contentItem.InternalName);
                break;
            case RichTextNodeType.Document or RichTextNodeType.Unknown:
            default:
                return null;
        }

        if (item is not null)
        {
            item.Content = MapRichTextNodes(contentItem.Content);
            item.Value = contentItem.Value;
        }

        return item;
    }
}