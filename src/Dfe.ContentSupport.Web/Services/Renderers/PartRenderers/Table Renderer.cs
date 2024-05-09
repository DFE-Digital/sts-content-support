using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class TableRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<table>");
        ExploreNode(node, sb);
        sb.Append("</table>");
    }
}
