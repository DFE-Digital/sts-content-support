using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class UnorderedListRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<ul>");

        ExploreNode(node, sb);

        sb.Append("</ul>");
    }
}
