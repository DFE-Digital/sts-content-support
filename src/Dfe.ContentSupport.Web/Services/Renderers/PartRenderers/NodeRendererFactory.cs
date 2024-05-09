namespace Dfe.ContentSupport.Web.Services;

public static class NodeRendererFactory
{
    public static NodeRenderer Create(string nodeType)
    {
        switch (nodeType)
        {
            case RichTextTags.Document:
                return new DocumentRenderer();
            case RichTextTags.Paragraph:
                return new ParagraphRenderer();
            case RichTextTags.UnorderedList:
                return new UnorderedListRenderer();
            case RichTextTags.OrderedList:
                return new OrderedListRenderer();
            case RichTextTags.ListItem:
                return new ListItemRenderer();
            case RichTextTags.Hyperlink:
                return new HyperlinkRenderer();
            case RichTextTags.Table:
                return new TableRenderer();
            case RichTextTags.TableRow:
                return new TableRowRenderer();
            case RichTextTags.TableHeaderCell:
                return new TableHeaderCellRenderer();
            case RichTextTags.TableCell:
                return new TableCellRenderer();
            case RichTextTags.Text:
                return new TextRenderer();
            default:
                Console.WriteLine("Unsupported node type");
                return null;
        }
    }
}
