using Dfe.ContentSupport.Web.Common;

namespace Dfe.ContentSupport.Web.Models.Mapped;

public class CsHeading(ContentItem contentItem)
    : RichTextContentItem(Utilities.ConvertToRichTextNodeType(contentItem.NodeType));