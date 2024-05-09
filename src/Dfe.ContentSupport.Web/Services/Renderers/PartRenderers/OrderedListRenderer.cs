using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class OrderedListRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<ol>");

        ExploreNode(node, sb);

        sb.Append("</ol>");
    }
}
