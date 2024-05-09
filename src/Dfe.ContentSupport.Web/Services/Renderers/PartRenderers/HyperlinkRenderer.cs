using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class HyperlinkRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<a href=\"");
        sb.Append(node.data.uri);
        sb.Append("\">");

        ExploreNode(node, sb);

        sb.Append("</a>");
    }
}
