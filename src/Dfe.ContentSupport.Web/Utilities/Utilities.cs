using Dfe.ContentSupport.Web.Common;
using Dfe.ContentSupport.Web.Models.Mapped;
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
            _ => throw new NotSupportedException(
                $"Failed to map content for node of type '{str}'")
        };
    }
}