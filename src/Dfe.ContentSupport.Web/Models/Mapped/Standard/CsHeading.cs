using Dfe.ContentSupport.Web.Common;

namespace Dfe.ContentSupport.Web.Models.Mapped.Standard;

public class CsHeading(ContentItem contentItem)
    : RichTextContentItem(Utilities.ConvertToRichTextNodeType(contentItem.NodeType),
        contentItem.InternalName);