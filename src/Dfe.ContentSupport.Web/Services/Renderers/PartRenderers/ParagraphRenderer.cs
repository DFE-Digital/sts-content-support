using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class ParagraphRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<p>");

        ExploreNode(node, sb);

        sb.Append("</p>");
    }
}
