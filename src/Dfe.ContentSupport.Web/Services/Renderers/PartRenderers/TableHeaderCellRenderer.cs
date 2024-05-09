using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class TableHeaderCellRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<th>");
        ExploreNode(node, sb);
        sb.Append("</th>");
    }
}
