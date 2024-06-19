namespace Dfe.ContentSupport.Web.Models.Mapped;

public enum CustomComponentType
{
    Undefined,
    Attachment,
    Card,
    GridContainer
}

public enum RichTextNodeType
{
    Unknown,
    Document,
    Paragraph,
    Text,
    Heading2,
    Heading3,
    Heading4,
    Heading5,
    Heading6,
    UnorderedList,
    OrderedList,
    ListItem,
    Hyperlink,
    Table,
    TableRow,
    TableHeaderCell,
    TableCell,
    Hr,
    EmbeddedAsset,
    EmbeddedEntry,
    EmbeddedEntryInline,
}

public class Paragraph() : RichTextContentItem(RichTextNodeType.Paragraph);


public class CsText() : RichTextContentItem(RichTextNodeType.Text)
{
    public bool IsBold { get; set; }
}

public class Hr(): RichTextContentItem(RichTextNodeType.Hr);

public class Hyperlink() : RichTextContentItem(RichTextNodeType.Hyperlink)
{
    public bool IsVimeo { get; set; }
    public string Uri { get; set; }
}
public class Heading2(): RichTextContentItem(RichTextNodeType.Heading2);
public class Heading3(): RichTextContentItem(RichTextNodeType.Heading3);
public class Heading4(): RichTextContentItem(RichTextNodeType.Heading4);
public class Heading5(): RichTextContentItem(RichTextNodeType.Heading5);
public class Heading6(): RichTextContentItem(RichTextNodeType.Heading6);
public class Table(): RichTextContentItem(RichTextNodeType.Table);
public class TableHeaderCell(): RichTextContentItem(RichTextNodeType.TableHeaderCell);
public class TableRow(): RichTextContentItem(RichTextNodeType.TableRow);
public class TableCell(): RichTextContentItem(RichTextNodeType.TableCell);
public class UnorderedList(): RichTextContentItem(RichTextNodeType.UnorderedList);
public class OrderedList(): RichTextContentItem(RichTextNodeType.OrderedList);
public class ListItem(): RichTextContentItem(RichTextNodeType.ListItem);

public class EmbeddedAsset() : RichTextContentItem(RichTextNodeType.EmbeddedAsset)
{
    public string Uri { get; set; }
    public AssetContentType AssetContentType { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
};

public class EmbeddedEntry() : RichTextContentItem(RichTextNodeType.EmbeddedEntry)
{
    public string JumpIdentifier { get; set; }
    public RichTextContentItem? RichText { get; set; }
    public CustomComponent? CustomComponent { get; set; }
}
public class EmbeddedEntryInline() : EmbeddedEntry();

public enum AssetContentType
{
    Unknown,
    Image,
    Video
}

public class CustomComponent(CustomComponentType type)
{
    public CustomComponentType Type { get; init; } = type;
}

public class CustomAttachment() : CustomComponent(CustomComponentType.Attachment)
{
    public string Uri { get; set; }
    public string ContentType { get; set; }
    public string  Title { get; set; }
    public long Size { get; set; }
}

public class CustomCard() : CustomComponent(CustomComponentType.Card)
{
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public string Meta { get; init; } = null!;
    public string ImageAlt { get; init; } = null!;
    public string Uri { get; init; } = null!;
    public string ImageUri { get; init; } = null!;
}


public class CustomGridContainer() : CustomComponent(CustomComponentType.GridContainer)
{
    public List<CustomCard> Cards { get; set; } = [];
}

