using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class TableCellRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<td>");
        ExploreNode(node, sb);
        sb.Append("</td>");
    }
}
