using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class TableRowRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<tr>");
        ExploreNode(node, sb);
        sb.Append("</tr>");
    }
}
