using System.Diagnostics;
using Dfe.ContentSupport.Web.Common;
using Dfe.ContentSupport.Web.Models;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.ViewModels;
using Paragraph = Dfe.ContentSupport.Web.Models.Mapped.Paragraph;

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


        foreach (var entry in entries)
        {
            items.Add(MapContentItem(entry));
        }

        return items;
    }

    private CsContentItem MapContentItem(Entry entry)
    {
        CsContentItem item;
        if (entry.RichText is not null)
        {
            item = MapRichTextContent(entry.RichText);
        }
        else
        {
            item = new CsContentItem();
        }

        item.InternalName = entry.InternalName;
        return item;
    }


    public RichTextContentItem MapRichTextContent(ContentItemBase richText)
    {
        var content = MapRichTextNodes(richText.Content);

        return new RichTextContentItem
        {
            NodeType = GetNodeType(richText.NodeType),
            Content = content
        };
    }

    private List<RichTextContentItem> MapRichTextNodes(List<ContentItem> nodes)
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

    private RichTextContentItem? MapContent(ContentItem contentItem)
    {
        RichTextContentItem? item = null;


        switch (GetNodeType(contentItem.NodeType))
        {
            case RichTextNodeType.Paragraph:
                item = new Paragraph();
                break;
            case RichTextNodeType.Text:
                var isBold = contentItem.Marks.Any(mark => mark.Type == "bold");
                item = new CsText
                {
                    IsBold = isBold
                };
                break;
            case RichTextNodeType.Heading2:
                item = new Heading2();
                break;
            case RichTextNodeType.Heading3:
                item = new Heading3();
                break;
            case RichTextNodeType.Heading4:
                item = new Heading4();
                break;
            case RichTextNodeType.Heading5:
                item = new Heading5();
                break;
            case RichTextNodeType.Heading6:
                item = new Heading6();
                break;
            case RichTextNodeType.UnorderedList:
                item = new UnorderedList();
                break;
            case RichTextNodeType.OrderedList:
                item = new OrderedList();
                break;
            case RichTextNodeType.ListItem:
                item = new ListItem();
                break;
            case RichTextNodeType.Hyperlink:
                var uri = contentItem.Data.Uri.ToString();
                item = new Hyperlink
                {
                    Uri = uri,
                    IsVimeo = uri.Contains("vimeo.com")
                };
                break;
            case RichTextNodeType.Table:
                item = new Table();
                break;
            case RichTextNodeType.TableRow:
                item = new TableRow();
                break;
            case RichTextNodeType.TableHeaderCell:
                item = new TableHeaderCell();
                break;
            case RichTextNodeType.TableCell:
                item = new TableCell();
                break;
            case RichTextNodeType.Hr:
                item = new Hr();
                break;
            case RichTextNodeType.EmbeddedAsset:
                var asset = contentItem.Data.Target.Fields;
                AssetContentType contentType = asset.File.ContentType switch
                {
                    "image/jpeg" or "image/png" => AssetContentType.Image,
                    "video/mp4" or "video/quicktime" => AssetContentType.Video,
                    _ => AssetContentType.Unknown
                };
                item = new EmbeddedAsset
                {
                    Uri = asset.File.Url,
                    Title = asset.Title,
                    Description = asset.Description,
                    AssetContentType = contentType
                };
                break;
            case RichTextNodeType.EmbeddedEntry:
            case RichTextNodeType.EmbeddedEntryInline:
                var target = contentItem.Data.Target;
                item = new EmbeddedEntry
                {
                    RichText = target.RichText is null
                        ? null
                        : MapRichTextContent(target.RichText),
                    JumpIdentifier = target.JumpIdentifier,
                    CustomComponent = GenerateCustomComponent(target),
                };
                break;
            case RichTextNodeType.Document:
            case RichTextNodeType.Unknown:
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

    public static RichTextNodeType GetNodeType(string nodeType)
    {
        return nodeType switch
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
            RichTextTags.EmbeddedEntryInline => RichTextNodeType.EmbeddedEntryInline,
            _ => throw new ArgumentOutOfRangeException(nameof(nodeType))
        };
    }

    public CustomComponent? GenerateCustomComponent(Target target)
    {
        var contentType = target.Sys.ContentType?.Sys.Id;
        if (contentType is null) return null;
        switch (contentType)
        {
            case "Attachment":
                return new CustomAttachment
                {
                    Uri = target.Asset.File.Url,
                    ContentType = target.Asset.File.ContentType,
                    Title = target.Title,
                    Size = target.Asset.File.Details.Size,
                };
            case "csCard":
                return new CustomCard
                {
                    Title = target.Title,
                    Description = target.Description,
                    ImageAlt = target.ImageAlt,
                    Meta = target.Meta,
                    ImageUri = target.Image.Fields.File.Url,
                    Uri = target.Uri
                };
            case "GridContainer":
                var cards = target.Content.Select(card => new CustomCard
                    {
                        Title = card.Title,
                        Description = card.Description,
                        ImageAlt = card.ImageAlt,
                        Meta = card.Meta,
                        ImageUri = card.Image.Fields.File.Url,
                        Uri = card.Uri
                    }).ToList();

                return new CustomGridContainer { Cards = cards };
            default:
                return null;
        }
    }
}