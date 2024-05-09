using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class ListItemRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<li>");

        ExploreNode(node, sb);

        sb.Append("</li>");
    }
}
